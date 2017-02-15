using System.Collections.Generic;
using UnityEngine;

namespace StellaQL
{
    /// <summary>
    /// This class to use when you want to reduce coding amount.
    /// </summary>
    public abstract class Code
    {
        /// <summary>
        /// String array to dictionary.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static Dictionary<string, int> HashesDic(string[] strings)
        {
            Dictionary<string, int> string_to_tagHash = new Dictionary<string, int>();
            foreach (string str in strings)
            {
                string_to_tagHash.Add(str, Animator.StringToHash(str));
            }
            return string_to_tagHash;
        }

        /// <summary>
        /// String array to hash set.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static HashSet<int> Hashes(string[] strings)
        {
            HashSet<int> hashSet = new HashSet<int>();
            foreach (string str in strings)
            {
                hashSet.Add(Animator.StringToHash(str));
            }
            return hashSet;
        }

        /// <summary>
        /// Change collection.
        /// </summary>
        public static void Register(Dictionary<int, AcStateRecordable> stateHash_to_record, List<AcStateRecordable> temp)
        {
            foreach (AcStateRecordable record in temp) { stateHash_to_record.Add(record.FullPathHash, record); }
        }
    }
}
