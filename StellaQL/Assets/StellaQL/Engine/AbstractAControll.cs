using System.Collections.Generic;
using UnityEngine;

namespace StellaQL
{
    /// <summary>
    /// This interface is a record corresponding to one animator state.
    /// </summary>
    public interface AcStateRecordable
    {
        /// <summary>
        /// It ends with a dot "." . It does not contain leaf node (state name).
        /// ex. "Base Layer.Japan."
        /// </summary>
        string GetBreadCrumb();
        /// <summary>
        /// Statemachine name or state name. This is a label of box.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Statemachine full path or state full path.
        /// </summary>
        string Fullpath { get; }
        /// <summary>
        /// Fullpath hash.
        /// </summary>
        int FullPathHash { get; }
        /// <summary>
        /// Your defined tags.
        /// </summary>
        HashSet<int> Tags { get; set; }
        /// <summary>
        /// (Option) for 2D fighting game.
        /// </summary>
        int Cliptype { get; set; }
        /// <summary>
        /// True if it contains all tags.
        /// </summary>
        /// <param name="requiredAllTags_hash"></param>
        /// <returns></returns>
        bool HasEverythingTags(HashSet<int> requiredAllTags_hash);
    }

    /// <summary>
    /// This abstract class is a record corresponding to one animator state.
    /// </summary>
    public abstract class AbstractAcState : AcStateRecordable
    {
        /// <param name="fullpath">Statemachine or state.</param>
        /// <param name="tags">Your defined tags.</param>
        public AbstractAcState(string fullpath, string[] tags)
        {
            Fullpath = fullpath;
            Name = Fullpath.Substring(Fullpath.LastIndexOf('.') + 1); // Does not include dots.
            FullPathHash = Animator.StringToHash(fullpath);
            Tags = Code.Hashes(tags);
        }

        public string GetBreadCrumb() {
            return Fullpath.Substring(0, Fullpath.LastIndexOf('.') + 1);// It ends with a dot.
        }
        public string Fullpath { get; set; }
        public string Name { get; set; }
        public int FullPathHash { get; set; }
        public bool HasEverythingTags(HashSet<int> requiredAllTags)
        {
            foreach (int tag in requiredAllTags)
            {
                if (!Tags.Contains(tag)) { return false; } // If there is a tag that does not have even one, it is false.
            }
            return true;
        }
        public HashSet<int> Tags { get; set; }
        public int Cliptype { get; set; }
    }

    /// <summary>
    /// For generators. For you.
    /// </summary>
    public class DefaultAcState : AbstractAcState
    {
        /// <summary>
        /// Correspond to statemachine or state.
        /// </summary>
        public DefaultAcState(string fullpath) :base(fullpath, new string[] { })
        {
        }

        /// <summary>
        /// Base for you.
        /// </summary>
        /// <param name="fullpath">Statemachine or state full path.</param>
        /// <param name="userDefinedTags_hash">Your defined tags.</param>
        public DefaultAcState(string fullpath, string[] userDefinedTags) : base(fullpath, userDefinedTags)
        {
        }
    }

    /// <summary>
    /// States.
    /// </summary>
    public interface AControllable
    {
        /// <summary>
        /// Mapping Statemachine, state name hash to state object.
        /// Calculate the name hash with Animator.StringToHash( ).
        /// </summary>
        Dictionary<int, AcStateRecordable> StateHash_to_record { get; }
    }

    /// <summary>
    /// States.
    /// </summary>
    public abstract class AbstractAControl : AControllable
    {
        public AbstractAControl()
        {
            StateHash_to_record = new Dictionary<int, AcStateRecordable>();
        }

        public Dictionary<int, AcStateRecordable> StateHash_to_record { get; set; }

        /// <summary>
        /// For your defined class.
        /// </summary>
        /// <param name="record">Your defined class.</param>
        public void Set(AcStateRecordable record)
        {
            StateHash_to_record[Animator.StringToHash(record.Fullpath)] = record;
        }
        public void SetTag(string fullpath, string[] tags)
        {
            StateHash_to_record[Animator.StringToHash(fullpath)].Tags = Code.Hashes(tags);
        }

        /// <summary>
        /// Current.
        /// </summary>
        /// <returns></returns>
        public AcStateRecordable GetCurrentAcStateRecord(Animator animator)
        {
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

            if (this.StateHash_to_record.ContainsKey(state.fullPathHash))
            {
                return this.StateHash_to_record[state.fullPathHash];
            }

            throw new UnityException("Not found [" + state.fullPathHash + "].");
        }

        /// <summary>
        /// Current.
        /// </summary>
        /// <returns></returns>
        public CliptypeExRecordable GetCurrentUserDefinedCliptypeRecord(Animator animator, UserDefinedCliptypeTableable userDefinedCliptypeTable)
        {
            AnimatorStateInfo animeStateInfo = animator.GetCurrentAnimatorStateInfo(0);

            int cliptype = (StateHash_to_record[animeStateInfo.fullPathHash]).Cliptype;

            if (userDefinedCliptypeTable.Cliptype_to_exRecord.ContainsKey(cliptype))
            {
                return userDefinedCliptypeTable.Cliptype_to_exRecord[cliptype];
            }

            throw new UnityException("Not found record. cliptype = [" + cliptype + "]");
        }
    }
}
