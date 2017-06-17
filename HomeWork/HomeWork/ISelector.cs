using System;
using System.Collections.Generic;

namespace HomeWork
{
    /// <summary>
    /// ISelector
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// 取值
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="pageSize">要取幾筆</param>
        /// <param name="source">要取的資料</param>
        /// <param name="selector">要Sum的條件</param>
        /// <returns><see cref="List{Int32}"/></returns>
        IEnumerable<int> Get<T>(int pageSize, IEnumerable<T> source, Func<T, int> selector);
    }
}