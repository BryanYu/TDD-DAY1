using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Model;
using FluentAssertions;
using ExpectedObjects;

namespace HomeWork.Tests
{
    [TestClass()]
    public class SumSelecterTests
    {
        private List<Product> _dummyProduct = new List<Product>()
        {
            new Product() {Id = 1,Cost = 1,Revenue =11,ShellPrice = 21 },
            new Product() {Id = 2,Cost = 2,Revenue =12,ShellPrice = 22 },
            new Product() {Id = 3,Cost = 3,Revenue =13,ShellPrice = 23 },
            new Product() {Id = 4,Cost = 4,Revenue =14,ShellPrice = 24 },
            new Product() {Id = 5,Cost = 5,Revenue =15,ShellPrice = 25 },
            new Product() {Id = 6,Cost = 6,Revenue =16,ShellPrice = 26 },
            new Product() {Id = 7,Cost = 7,Revenue =17,ShellPrice = 27 },
            new Product() {Id = 8,Cost = 8,Revenue =18,ShellPrice = 28 },
            new Product() {Id = 9,Cost = 9,Revenue =19,ShellPrice = 29 },
            new Product() {Id = 10,Cost = 10,Revenue =20,ShellPrice = 30 },
            new Product() {Id = 11,Cost = 11,Revenue =21,ShellPrice = 31 }
        };
        

        [TestMethod()]
        public void Input_PageSize_Zero_Shoud_Throw_Exception()
        {
            ///Arrange
            var selector = GetSelector();
            var pageSize = 0;

            ///Act
            Func<Product, int> func = (item) => item.Cost;
            Action act =
                () => selector.Get(pageSize, _dummyProduct.ToList(), func);
            ///Assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void Input_PageSize_Negative_Number_Should_Throw_Exception()
        {
            ///Arrange
            var pageSize = -1;
            var selector = GetSelector();

            ///Act
            Func<Product, int> func = (item) => item.Cost;
            Action act = () => selector.Get(pageSize, _dummyProduct.ToList(), func);

            ///Assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void Input_PageSize_Is_3_And_Data_Should_Return_SumBy3_Total()
        {
            ///Arrange
            var pageSize = 3;
            var expected = new List<int>() { 6, 15, 24, 21 };
            var selector = GetSelector();

            ///Act
            var actual = selector.Get(pageSize, _dummyProduct, item => item.Cost);

            ///Assert
            CollectionAssert.AreEquivalent(expected, actual.ToList());

        }

        [TestMethod()]
        public void Input_PageSize_Is_3_And_Data_Should_Not_Return_SumBy3_Total()
        {
            ///Arrange
            var pageSize = 3;
            var expected = new List<int>() { 6, 15, 24, 21, 5 };
            var selector = GetSelector();

            ///Act
            var actual = selector.Get(pageSize, _dummyProduct, item => item.Cost);

            ///Assert
            CollectionAssert.AreNotEquivalent(expected, actual.ToList());

        }
        [TestMethod()]
        public void Input_PageSize_Is_4_And_Data_Should_Return_SumBy4_Total()
        {
            ///Arrange
            var pageSize = 4;
            var expected = new List<int>() { 50, 66, 60 };
            var selector = GetSelector();

            ///Act
            var actual = selector.Get(pageSize, _dummyProduct, item => item.Revenue);

            ///Assert
            CollectionAssert.AreEquivalent(expected, actual.ToList());

        }

        [TestMethod]
        public void Input_PageSize_Is4_And_Data_Should_Not_Return_SumBy4_Total()
        {
            ///Arrange
            var pageSize = 4;
            var expected = new List<int>() { 1, 2, 3, 4 };
            var selector = GetSelector();

            ///Act
            var actual = selector.Get(pageSize, _dummyProduct, item => item.Revenue);

            ///Assert
            CollectionAssert.AreNotEqual(expected, actual.ToList());


        }

        private ISelector GetSelector()
        {
            return new SumSelecter();
        }
    }
}