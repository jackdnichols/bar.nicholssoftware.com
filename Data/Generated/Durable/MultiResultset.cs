/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OxyData.Data
{
    /// <summary>
    /// This is a set of collection objects (List[T]). 
    /// This class is typically used to return data from DB queries that return multiple result-sets.
    /// The first result-set is the instance of the class. Subsequent result-sets are added to the 'AdditionalResultsets' 
    /// property.
    /// </summary>
    /// <typeparam name="TFirst">The Type of the items in the first collection</typeparam>
    [Serializable]
    public class MultiResultset<TFirst>:List<TFirst>
    {

        #region Fields 
        private List<Object>    _AdditionalResultsets;
        private int             _ResultsetCount;
        #endregion

        #region Properties 

        /// <summary>
        /// The total number of resultsets that this instance contains. 
        /// if the value is 1, then the 'AdditionalResultsets' property is null 
        /// (since the first result-set is the instance itself.)
        /// </summary>
        [XmlIgnore]
        public int ResultsetCount
        {
            get 
            {
                if (_ResultsetCount == 0)
                {
                    if (_AdditionalResultsets != null)
                    {
                        _ResultsetCount = 1 + _AdditionalResultsets.Count;
                    }
                }

                return _ResultsetCount; 
            }
        }

        /// <summary>
        /// The additional result-sets. If this instance contains only one result-set, then 
        /// this property is null.
        /// </summary>
        public List<Object> AdditionalResultsets
        {
            get { return _AdditionalResultsets; }
        }

        /// <summary>
        /// The first result-set (this is the instance of the MultiResultset itself).
        /// </summary>
        [XmlIgnore]
        public List<TFirst> FirstResultset
        {
            get { return this; }
        }
        
        #endregion

        #region Constructors 

        public MultiResultset() : base() { }

        public MultiResultset(int capacity) : base(capacity) { }

        public MultiResultset(List<TFirst> collection) : base(collection) 
        {

        }

        public MultiResultset(List<TFirst> firstCollection, List<object> otherCollections)
            : base(firstCollection)
        {
            _AdditionalResultsets = otherCollections;
        }
        #endregion

        #region Methods 

        /// <summary>
        /// Returns one of the additional resultsets. The first resultset can't be retrieved with 
        /// this call. If total result-set count is 2, IdxPosition '0' will return the second result-set. 
        /// </summary>
        public List<T> GetAdditionalResultset<T>(int IdxPosition)
        {
            List<T> val=null;
            if (_AdditionalResultsets != null && _AdditionalResultsets.Count > IdxPosition)
            {
                val = (List<T>)(_AdditionalResultsets[IdxPosition]);
            }
            return val;
        }

        /// <summary>
        /// Returns all the result-sets in this instance
        /// </summary>
        public List<object> GetAllResultSets()
        {
            List<object> val = new List<object>(6);

            val.Add(this);

            if (_AdditionalResultsets != null)
                val.AddRange(_AdditionalResultsets);

            return val;
        }

        #endregion

    }
}