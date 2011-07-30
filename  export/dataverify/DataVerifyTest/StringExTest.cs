using DataVerify;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace DataVerifyTest
{
    
    
    /// <summary>
    ///这是 StringExTest 的测试类，旨在
    ///包含所有 StringExTest 单元测试
    ///</summary>
    [TestClass()]
    public class StringExTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试属性
        // 
        //编写测试时，还可使用以下属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///IsMatch 的测试
        ///暂未设定该函数的测试方法
        ///</summary>
        [TestMethod()]
        public void IsMatchTest()
        {
            Assert.IsTrue(true, "");
        }

        /// <summary>
        ///IsDateTime 的测试
        ///</summary>
        [TestMethod()]
        public void IsDateTimeTest()
        {
            string str = DateTime.MinValue.ToString(); // TODO: 初始化为适当的值
            bool actual;
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(actual, "最小时间的字符串验证失败");

            str = DateTime.MaxValue.ToString();
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(actual, "最大时间的字符串验证失败");

            str = "2001-12-02";
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(actual, string.Format("时间[{0}]的字符串验证失败", str));

            str = "2001-13-02";
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(!actual, string.Format("时间[{0}]的字符串验证失败", str));

            str = "2001-12-35";
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(!actual, string.Format("时间[{0}]的字符串验证失败", str));

            str = "12544-12-02";
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(!actual, string.Format("时间[{0}]的字符串验证失败", str));

            str = "2001-12-02 25:00:00";
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(!actual, string.Format("时间[{0}]的字符串验证失败", str));

            str = "2001-12-02 23:61:00";
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(!actual, string.Format("时间[{0}]的字符串验证失败", str));

            str = "2001-12-02 23:59:61";
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(!actual, string.Format("时间[{0}]的字符串验证失败", str));

            str = "2001-12-02 3333";
            actual = StringEx.IsDateTime(str);
            Assert.IsTrue(!actual, string.Format("时间[{0}]的字符串验证失败", str));
        }

        /// <summary>
        ///IsUInt 的测试
        ///</summary>
        [TestMethod()]
        public void IsUIntTest()
        {
            string str = "2000"; // TODO: 初始化为适当的值
            bool actual;
            actual = StringEx.IsUInt(str);
            Assert.IsTrue(actual, string.Format("【{0}】的字符串验证失败", str));

            str = "-200";
            actual = StringEx.IsUInt(str);
            Assert.IsTrue(!actual, string.Format("【{0}】的字符串验证失败", str));

            str = "-200b";
            actual = StringEx.IsUInt(str);
            Assert.IsTrue(!actual, string.Format("【{0}】的字符串验证失败", str));

            str = "-b200";
            actual = StringEx.IsUInt(str);
            Assert.IsTrue(!actual, string.Format("【{0}】的字符串验证失败", str));

            str = "b200";
            actual = StringEx.IsUInt(str);
            Assert.IsTrue(!actual, string.Format("【{0}】的字符串验证失败", str));

            str = "-200b";
            actual = StringEx.IsUInt(str);
            Assert.IsTrue(!actual, string.Format("【{0}】的字符串验证失败", str));

            str = "200.3";
            actual = StringEx.IsUInt(str);
            Assert.IsTrue(!actual, string.Format("【{0}】的字符串验证失败", str));
        }

        /// <summary>
        ///IsIDCard 的测试
        ///</summary>
        [TestMethod()]
        public void IsIDCardTest()
        {
            string str = "383483374777277727"; // TODO: 初始化为适当的值
            bool actual;
            actual = StringEx.IsIDCard(str);
            Assert.IsTrue(actual, string.Format("【{0}】的字符串验证失败", str));

            str = "3834833747772777274";
            actual = StringEx.IsIDCard(str);
            Assert.IsTrue(!actual, string.Format("【{0}】的字符串验证失败", str));

            str = "383483374777277";
            actual = StringEx.IsIDCard(str);
            Assert.IsTrue(actual, string.Format("【{0}】的字符串验证失败", str));

            str = "38348337477727772x";
            actual = StringEx.IsIDCard(str);
            Assert.IsTrue(actual, string.Format("【{0}】的字符串验证失败", str));

            str = "38348337477727772X";
            actual = StringEx.IsIDCard(str);
            Assert.IsTrue(actual, string.Format("【{0}】的字符串验证失败", str));

            str = "383483374777277724X";
            actual = StringEx.IsIDCard(str);
            Assert.IsTrue(!actual, string.Format("【{0}】的字符串验证失败", str));

            str = "3834833747772B77274";
            actual = StringEx.IsIDCard(str);
            Assert.IsTrue(!actual, string.Format("【{0}】的字符串验证失败", str));
        }
    }
}
