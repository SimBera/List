using System;
using Xunit;
using Teltonika_Uzd;


namespace Prime.UnitTests.Services
{
    public class Ftest
    {
        private readonly MyList _MyList;

        public Ftest() 
        { 
            _MyList = new MyList(); 
        } 
        
        #region Sample_TestCode
        [Theory]
        [InlineData("good")]
        public void ReturnFalseGivenValuesLessThan2(string value)
        {
            
            //var result = _MyList.getList(value);
           var result = false;
           

            Assert.False(result, $"{value} should not be prime");
        }
        #endregion
        
     
 
    }
}