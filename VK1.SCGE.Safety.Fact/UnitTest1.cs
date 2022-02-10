using System;
using Xunit;


namespace VK1.SCGE.Safety.Fact {
    public class UnitTest1 {
        [Fact]
        public void Test1() {
            //arrange
            var words = "ssddksjifjskdfjsal;fjasdklfajfiejdklj;aslfjsklfjihfksf;lsdl;kfjasklfjslk;fjasl;kfja;fiefalkfaslk;jl;kjกรด่ากห่ดฟด่ร่ดาสฟก่ดวฟดาฟ่ดฟรด่ฟหสกาด่หฟวด่าส";

            //act
            var result =Math.Ceiling(words.Length/20.0);

            var length = words.Length;

            //assert
            Assert.Equal(8.0,length);
        }
    }
}
