using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    /// <summary>
    /// 分頁取值
    /// </summary>
    public class SumSelecter : ISelector 
    {
        /// <summary>
        /// 取值
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="pageSize">要取幾筆</param>
        /// <param name="data">要取的資料</param>
        /// <param name="selector">要Sum的條件</param>
        /// <returns><see cref="List{Int32}"/></returns>
        public IEnumerable<int> Get<T>(int pageSize, IEnumerable<T> source, Func<T, int> seletor)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();

            }
            var result = GetResult<T>(pageSize, source, seletor);
            return result;
        }

        private IEnumerable<int> GetResult<T>(int pageSize, IEnumerable<T> source, Func<T, int> seletor)
        {
            var count = GetPageCount(pageSize, source.Count());
            var result = new List<int>();

            for (var index = 0; index < count; index++)
            {
                yield return source.ToList().Skip(index * pageSize).Take(pageSize).Sum(seletor);
            }

        }

        /// <summary>
        /// 取得頁數
        /// </summary>
        /// <param name="pageSize">要取幾筆</param>
        /// <param name="dataCount">資料筆數</param>
        /// <returns></returns>
        private int GetPageCount(int pageSize, int dataCount)
        {
            var temp = dataCount % pageSize;
            var result = dataCount / pageSize;
            if (temp != 0)
            {
                result = result + 1;
            }
            return result;
        }
    }
}


