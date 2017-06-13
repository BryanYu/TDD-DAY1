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
        /// <param name="take">要取幾筆</param>
        /// <param name="data">要取的資料</param>
        /// <param name="selector">要Sum的條件</param>
        /// <returns><see cref="List{Int32}"/></returns>
        public List<int> Get<T>(int take, List<T> data, Func<T, int> seletor)
        {
            if (take <= 0)
            {
                throw new ArgumentException();
            }

            var count = GetPageCount(take, data.Count());
            var result = new List<int>();
            
            for (var index = 0; index < count; index++)
            {
                var sum = data.ToList().Skip(index * take).Take(take).Sum(seletor);
                result.Add(sum);
            }
            return result;

        }

        /// <summary>
        /// 取得頁數
        /// </summary>
        /// <param name="take">要取幾筆</param>
        /// <param name="dataCount">資料筆數</param>
        /// <returns></returns>
        private int GetPageCount(int take, int dataCount)
        {
            var temp = dataCount % take;
            var result = dataCount / take;
            if (temp != 0)
            {
                result = result + 1;
            }
            return result;
        }
    }
}


