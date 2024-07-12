using BUS.Services;
using DAL.Models.DomainClass;
using NUnit.Framework;
using System.Numerics;
using System.Text.RegularExpressions;
namespace TestProject5
{   
    public class Tests
    {
        private bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length >= 251 || !System.Text.RegularExpressions.Regex.IsMatch(name, "^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Vui lòng nhập tên hợp lệ!");
            }
            else
            {
                return true;
            }
        }    
        private void CheckIdContain ( int id )
        {
            if ( id<0)
            {
                throw new ArgumentException("Id không được phép là số âm");
            }
            List<Mausac> mausacs = _services.GetAll(null, null);
            foreach( var item in mausacs)
            {
                if(item.Mamausac==id)
                {
                    throw new ArgumentException("Id đã tồn tại");
                }    
            }    
                
        }
        private MauSacService _services;
        long expected , actual ;
        [SetUp]
        public void Setup()
        {
            _services = new MauSacService();
        }
    
        [TestCase("")] // tên trống
        public void Test_Add_01(string name )
        {

            var mauSac = new Mausac();
            mauSac.Mamausac = 123;
            mauSac.Tenmausac = "";
            _services.Them(mauSac);
            var MS = _services.GetAll(null, null);
            Assert.IsTrue(IsValidName(mauSac.Tenmausac));
            Assert.AreEqual(7, MS.Count);
        }
        [TestCase("@@@")] // tên có kí tự đặc biệt
        public void Test_Add_06(string name )
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = 123;
            mauSac.Tenmausac = "@@@";
            _services.Them(mauSac);
            var MS = _services.GetAll(null, null);
            Assert.IsTrue(IsValidName(mauSac.Tenmausac));
            Assert.AreEqual(7, MS.Count);
        }
        [Test] // thành công
        public void Test_Add_02()
        {

            var mauSac = new Mausac
            {
                Mamausac = 14,
                Tenmausac = "đỏ ",
                Mota = "Đỏ đô",
            };
            _services.Them(mauSac);
            var MS = _services.GetAll(null, null);
            Assert.IsTrue(IsValidName(mauSac.Tenmausac));
            Assert.AreEqual(7, MS.Count);
        }
        [Test]
        public void Test_Add_03()
        {

            var mauSac = new Mausac
            {
                Mamausac = 15,
                Tenmausac = "Trắng",
                Mota = "Trắng tinh",
            };
            _services.Them(mauSac);
            var MS = _services.GetAll(null, null);
            Assert.AreEqual(7, MS.Count);
        }
        [Test]
        public void Test_Add_04()
        {

            var mauSac = new Mausac
            {
                Mamausac = 16,
                Tenmausac = "Hồng ",
                Mota = "Hồng cánh sen",
            };
            _services.Them(mauSac);
            var MS = _services.GetAll(null, null);

            Assert.AreEqual(7, MS.Count);
        }
        [Test]
        public void Test_Add_05()
        {

            var mauSac = new Mausac
            {
                Mamausac = 17,
                Tenmausac = "đen",
                Mota = "Đen đậm",
            };
            _services.Them(mauSac);
            var MS = _services.GetAll(null, null);
            Assert.AreEqual(7, MS.Count);
        }
        [Test]
        public void Test_Add_Exception_01()
        {
            var mauSac = new Mausac { Mamausac = 17, Tenmausac = "@@@", Mota = "Nâu" };
            _services.Them(mauSac);
            Assert.Throws(typeof(ArgumentException), () => IsValidName(mauSac.Tenmausac));
        }
        [Test]
        public void Test_Add_Exception_02()
        {
            var mauSac = new Mausac { Mamausac = 111, Tenmausac = "", Mota = "Đen đậm" };
            _services.Them(mauSac);
            Assert.Throws(typeof(ArgumentException), () => IsValidName(mauSac.Tenmausac));
        }
        [Test]
        public void Test_Add_Exception_03()
        {
            var mauSac = new Mausac { Mamausac = 111, Tenmausac = "123", Mota = "Đen " };
            _services.Them(mauSac);
            Assert.Throws(typeof(ArgumentException), () => IsValidName(mauSac.Tenmausac));
        }
        [TestCase(1)]
        public void Test_Update_01(int id )
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = id;
            mauSac.Tenmausac = "hồng nhạt";
            _services.Sua(id,mauSac);
            expected = _services.Sua(id, mauSac) ? 1 : 0; 
            actual = 1; 
            Assert.AreEqual(expected, actual); 
        }
        [TestCase(2)]
        public void Test_Update_02(int id)
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = id;
            mauSac.Tenmausac = "TÍM";
            _services.Sua(id, mauSac);
            expected = _services.Sua(id, mauSac) ? 1 : 0; // Sử dụng giá trị 1 hoặc 0 thay vì true hoặc false
            actual = 1; // Hoặc gán cho actual giá trị kiểu long mong muốn
            Assert.AreEqual(expected, actual);
        }
        [TestCase(3)]
        public void Test_Update_03(int id)
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = id;
            mauSac.Tenmausac = "Trắng ";
            _services.Sua(id, mauSac);
            expected = _services.Sua(id, mauSac) ? 1 : 0; 
            actual = 1; 
            Assert.AreEqual(expected, actual);
        }
        [TestCase(4)]
        public void Test_Update_04(int id)
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = id;
            mauSac.Tenmausac = "Đen";
            _services.Sua(id, mauSac);
            expected = _services.Sua(id, mauSac) ? 1 : 0; 
            actual = 1; 
            Assert.AreEqual(expected, actual);
        }
        [TestCase(6)]
        public void Test_Update_05(int id)
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = id;
            mauSac.Tenmausac = "hồng cánh sen";
            _services.Sua(id, mauSac);
            expected = _services.Sua(id, mauSac) ? 1 : 0; 
            actual = 1; 
            Assert.AreEqual(expected, actual);
        }
        [TestCase(7)]
        public void Test_Update_06(int id)
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = id;
            mauSac.Tenmausac = "Vàng nhạt";
            _services.Sua(id, mauSac);
            expected = _services.Sua(id, mauSac) ? 1 : 0; 
            actual = 1; 
            Assert.AreEqual(expected, actual);
        }
        [TestCase(8)]
        public void Test_Update_07(int id)
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = id;
            mauSac.Tenmausac = "Tím mộng mơ";
            _services.Sua(id, mauSac);
            expected = _services.Sua(id, mauSac) ? 1 : 0; 
            actual = 1; 
            Assert.AreEqual(expected, actual);
        }
        [TestCase("@Adidas")]
        public void Test_Update_Exception_01 (string name)
        {
            var mauSac = new Mausac ();
            mauSac.Mamausac = 1;
            mauSac.Tenmausac= name;
            Assert.Throws(typeof(ArgumentException), () => IsValidName(mauSac.Tenmausac));
        }
        [TestCase("")]
        public void Test_Update_Exception_02(string name)
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = 1;
            mauSac.Tenmausac = name;
            Assert.Throws(typeof(ArgumentException), () => IsValidName(mauSac.Tenmausac));
        }
        [TestCase("123")]
        public void Test_Update_Exception_03(string name)
        {
            var mauSac = new Mausac();
            mauSac.Mamausac = 1;
            mauSac.Tenmausac = name;
            Assert.Throws(typeof(ArgumentException), () => IsValidName(mauSac.Tenmausac));
        }
        [TestCase(0)]
        public void Test_Khoa_0 ( int id)
        {
            _services.Khoa_MoKhoa(id);
            expected = _services.Khoa_MoKhoa(id) ? 1:0;
            actual = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1)]
        public void Test_Khoa_01(int id)
        {
            _services.Khoa_MoKhoa(id);
            expected = _services.Khoa_MoKhoa(id) ? 1 : 0;
            actual =1;
            Assert.AreEqual(expected, actual);
        }
        [TestCase(2)]
        public void Test_Khoa_02(int id)
        {
            _services.Khoa_MoKhoa(id);
            expected = _services.Khoa_MoKhoa(id) ? 1 : 0;
            actual = 1;
            Assert.AreEqual(expected, actual);
        }
        [TestCase(3)]
        public void Test_Khoa_03(int id)
        {
            _services.Khoa_MoKhoa(id);
            expected = _services.Khoa_MoKhoa(id) ? 1:0;
            actual = 1;
            Assert.AreEqual(expected, actual);
        }
        [TestCase(4)]
        public void Test_Khoa_04(int id)
        {
            _services.Khoa_MoKhoa(id);
            expected = _services.Khoa_MoKhoa(id) ? 1 : 0;
            actual = 1;
            Assert.AreEqual(expected, actual);
        }
        [TestCase(7)]
        public void Test_Khoa_05(int id)
        {
            _services.Khoa_MoKhoa(id);
            expected = _services.Khoa_MoKhoa(id) ? 1 : 0;
            actual = 1;
            Assert.AreEqual(expected, actual);
        }
    }
}