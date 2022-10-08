using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SuddanApplication.Application.Common.Interfaces;

namespace SuddanApplication.Infrastructure.Identity
{
    public class Sec : ISec
    {
        //4096
        public string publicKeySTR => "<?xml version=\"1.0\" encoding=\"utf-16\"?><RSAParameters xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Exponent>AQAB</Exponent><Modulus>x9nDisVsWLsi6miogXbdUP9ikxf9A+KEMTx6zQPQMdEJJ4cBj1fvig3wikWWE5TnRDGfSiUF36L7sEzEcgHL99WvvWONIxj+JKuBBo0p8FAxnMPtXrSmy5v3lhj1z370xv1adH+PVJPQMMFOEwx5VE05dCrDKedV9py8u51MXYsf0EeMG97enS5cUbEEuLu0rTerEGOfMQtRtbnQGHzIJRMm0R47IBsuHws9plk9C8LiURvOPCy44POALdD3EcG9vnSDxnOpQuxjuKMBaNW+p80fvf5fF03uZl0kHjVdyBJS82isdARsx3OOqwpWWk3pLmyVe/98R9Pfi5ouU0D27Q+tcOrhmHr/sRiqA9l79AzdYAx+28KRqmopnsN+02ZboCYrnCoO1zE5hp+r/pr6UCzlUtN6pnBOpIt9r2bxr10YbqwpXNMnDYF1zRsDvT99ymmnI/mamR957/ppVv6v019vDIcBPGbubAdyMsXURUP+EQoMSrTag2Wx5FW3Sh8ivgcX3pvwvZSj0bjo+aS4YtKxGaMkMtKy0YaJFxtaPBrK32LtbzpdhfMSgtQ1WCZFv3FyIBwdFtiO2AA9lJbgAaKH1mmOzWmatbMFVSOxSqVy5Y22ZwEu85XWkMPQB18iyXNl2zI3VcUCFj0lRCnwAGZZRCHe6fixP3WaFaReGoE=</Modulus></RSAParameters>";
        public string publicKeyExport = "MIICCgKCAgEAx9nDisVsWLsi6miogXbdUP9ikxf9A+KEMTx6zQPQMdEJJ4cBj1fvig3wikWWE5TnRDGfSiUF36L7sEzEcgHL99WvvWONIxj+JKuBBo0p8FAxnMPtXrSmy5v3lhj1z370xv1adH+PVJPQMMFOEwx5VE05dCrDKedV9py8u51MXYsf0EeMG97enS5cUbEEuLu0rTerEGOfMQtRtbnQGHzIJRMm0R47IBsuHws9plk9C8LiURvOPCy44POALdD3EcG9vnSDxnOpQuxjuKMBaNW+p80fvf5fF03uZl0kHjVdyBJS82isdARsx3OOqwpWWk3pLmyVe/98R9Pfi5ouU0D27Q+tcOrhmHr/sRiqA9l79AzdYAx+28KRqmopnsN+02ZboCYrnCoO1zE5hp+r/pr6UCzlUtN6pnBOpIt9r2bxr10YbqwpXNMnDYF1zRsDvT99ymmnI/mamR957/ppVv6v019vDIcBPGbubAdyMsXURUP+EQoMSrTag2Wx5FW3Sh8ivgcX3pvwvZSj0bjo+aS4YtKxGaMkMtKy0YaJFxtaPBrK32LtbzpdhfMSgtQ1WCZFv3FyIBwdFtiO2AA9lJbgAaKH1mmOzWmatbMFVSOxSqVy5Y22ZwEu85XWkMPQB18iyXNl2zI3VcUCFj0lRCnwAGZZRCHe6fixP3WaFaReGoECAwEAAQ==";

        //2048
        //public string publicKeySTR => "<?xml version=\"1.0\" encoding=\"utf-16\"?><RSAParameters xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Exponent>AQAB</Exponent><Modulus>wbxtS+ERCCTothgZzvxZqTIbCSY681KJcuRfsHBrYj1tPKKuORxFNT217O7wi4BsHX500N5HcK2D5U9JTZ+mNREI/mWVtl7BAPokvgfGMXS3y/DQWMSobziq7k26237uELfFFFnLhdS1TkRjk83MRDtjbufypYhnxTEEkUxBQAMsxj2EYtEw9k+rcSTfl203Qj5jdECO2LgKGL0Oz7Yb8PT1rM6Q3l3/2TXD1cfpfWA/bRsYYeokgikL+Hn27qFqhFgnuVBB4Tcm3t6mUojfc9wlCXngz1STNClDBMWt+UKg134Mxs1z+dhjEMP8ty3cnIj735CJnppASbNxSF4CNQ==</Modulus></RSAParameters>";

        //1024
        //public string publicKeySTR => "<?xml version=\"1.0\" encoding=\"utf-16\"?><RSAParameters xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Exponent>AQAB</Exponent><Modulus>ojcM3wURF2qVhDA997vzVRmqPejZ2YiwgsTCV7C7prh77++rc8fyjcTchQrKgP/6XVh4UeAOXBQmrm8H++/qjep706hSm+ipP+1HbSeEtmRS0eYrAp0plKOKJLL5THx8ZeSWC56lvzvn8U3Q5GUglBL89MBN1HOoBi30SXVZHi0=</Modulus></RSAParameters>";

        //4096
        public string privateKeySTR => "<?xml version=\"1.0\" encoding=\"utf-16\"?><RSAParameters xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><D>OdE2UR9siP8aytYcadgJjzVTP1rhSA5wUA4/OLCxurfO/jCAswettTLzNA2NrXyWq5PvkXPEjz6HsimDa7g5Winn/dKfMlg4rkMvwMV2LKAGumO0eIGq/5zPtAzkkHMaPbduQ+XjgYSB5pkGDVy+fTUaOhFlBOp4ZDBUKbMINMfbHFaWojmIDdErxDaCNy+WxcYlJ0iq9XVg3kIzgeIXxSIVSMqGMHOslC6cV1PZ5V0sPGre72nA0tOfcaHS2MBENKVgujkb7tCUyQXfkoTD86fUVxMQT52sKtEncdXem9MxTFosCiR9k/ZKgBEtilKf815WoNj5C46wTaL9Y/iXdtr/11o3inL2b0lkSEK1C6+TPjmb8cZqfIoRvAlx7c5tZQ8lwpWcudM+8mTM6NtQqejKlGUeBr0t42kfBWHwYKYRFK1DBTb6XBIQUm39WktD1G4IRV1ZkCLm1lTKlIAb5PSQQGJ6vTZ14RErCc646iX0HHucBZT/DgaoIc9UL+w0hAotWE0ZxQyhyiXrrYYnF4gGXWAxSlMG12t2ubMy83SgfkKo/YSwl1pynkYgsYl4v1lyyddSvN0fjrjns9cQZ3oE4KJApqiHGIgj/jZMkO6/34o8xn2pJfbCXf+hoXMsS+l8CvqL0PSqfG+NCFty0OF6kRSFIbSbauUPefzvLUE=</D><DP>kXGgSNGX3t0jmW6nTlZhQBIguob67vYuw3S09BlOdp4sFfQ+2JEg4L/Gxc3/xMQj5R2CHnkvaU/+E+0YCtAVOLzP30ApMY+yhcDuaL4+19Gl006WMHEYeiuPuqXODMlRXaPm6zIJYgP4XO/lmJ7oeyoT9sQSkTs2+LST64Yc3YaxBTKGK8GV19lKX46PCqSnj+uQJ8oxhym468D4GWizcATBG0v5KmtHtLdzFfdCtMvstf00hgIqOhz9phJX3AvfjK5hEioeo6I2xqw5qt/RmLHJyel7VdvuzlyFmWI+l/xFtCdZctBIjB9Oj/tf1A93wmi2VXYJFmPvYUVC2H6Tqw==</DP><DQ>hPslBaCCJsq+Nvt6HJRJF9KE1W9cKY72090NkYTKqCaeqeKkI1BaPPKkp12GOmpoeGwB8jIf6IWhQWEh5dX4alZueCFgqtfxHjXh5ESkSflfD0dF1yEGIGVo5bwoqmDvfuY/fPU3qehTUB8k4AP61cUlXQ6M6M7pYj0B+sFAQmczKfoOFd6B2ng6bYEHQSAUKKOaw1W4RvAfcNsglMlYs53x6xONKntArtry6cZFfQ8dE5utMkVcxspWH9HaHraWuIKVr2rW+jrSv347t5QAz/PydB+x/w3ZxEZXoha88fELF1oZBfHjMovAgjzIL0yNK4bPvfBT7Kj4vt4aYJdhcQ==</DQ><Exponent>AQAB</Exponent><InverseQ>qcpRY3c2ynyoN03SOlwft4rxiogHjyeNJ+B+aRX7ZMyAxCCIJ1r0ZlyuIsjQaQdQwfBylVMvrZx2mitezsWF9yUp4xyRDxSPnAqrXfIU+4AhP3AgehQSIv9uMcGKafEybud/sFIQzR2lp0+IflFs/ojas+kYN+T5UzM0HOYo1G1MTpR1wpaQukjdOqUJb7D9fW060X0REIcrXhqwMsQyi7Nz8KPjwSkhRT/H/DGdE+6RHdtSwbKr8sQx1KcyUznT0G5o9COCWGZrVsyps42dHZ83PPd5UFT3GLzbgvFe0dSnHi+mwYoIemb2FM/9P/MYOndOpq2s+RPYQg2x8wU/Lw==</InverseQ><Modulus>x9nDisVsWLsi6miogXbdUP9ikxf9A+KEMTx6zQPQMdEJJ4cBj1fvig3wikWWE5TnRDGfSiUF36L7sEzEcgHL99WvvWONIxj+JKuBBo0p8FAxnMPtXrSmy5v3lhj1z370xv1adH+PVJPQMMFOEwx5VE05dCrDKedV9py8u51MXYsf0EeMG97enS5cUbEEuLu0rTerEGOfMQtRtbnQGHzIJRMm0R47IBsuHws9plk9C8LiURvOPCy44POALdD3EcG9vnSDxnOpQuxjuKMBaNW+p80fvf5fF03uZl0kHjVdyBJS82isdARsx3OOqwpWWk3pLmyVe/98R9Pfi5ouU0D27Q+tcOrhmHr/sRiqA9l79AzdYAx+28KRqmopnsN+02ZboCYrnCoO1zE5hp+r/pr6UCzlUtN6pnBOpIt9r2bxr10YbqwpXNMnDYF1zRsDvT99ymmnI/mamR957/ppVv6v019vDIcBPGbubAdyMsXURUP+EQoMSrTag2Wx5FW3Sh8ivgcX3pvwvZSj0bjo+aS4YtKxGaMkMtKy0YaJFxtaPBrK32LtbzpdhfMSgtQ1WCZFv3FyIBwdFtiO2AA9lJbgAaKH1mmOzWmatbMFVSOxSqVy5Y22ZwEu85XWkMPQB18iyXNl2zI3VcUCFj0lRCnwAGZZRCHe6fixP3WaFaReGoE=</Modulus><P>36+/2p7Iqsnz6o32hqna7I/TYTsFYFylmiULiIkJJihmJzs4pm7lanOqp3WSQjDSRaLRdZf/GhNBrhyuDOSZiLbTW7SerpKrQpcpwa55l+RZ4PeqHDH24ElNuJRRmSKDqtgw99p+Bt5m6jZPv1ZzCHripWmK8dCaAl1Ax7QRG3teUvAFqSpSIcTvXsNF8PF4DW155TuAMP49g6SWkEtW/+9gulxjESRpnOHb4QoExTU0ulFekn4NTWooeSkMmaXM1LomDhzms2D1WpshEPG5Dcic/Nd2ZiLV94Z6mgVSk0MuPiLwA86jWQ+nX0woGmGGjO2XX5m3+NIz+Pyts3XTww==</P><Q>5LiHcwDbxPbXwS4tM7+Ke0SBek3WWgxdUyx1e5TotOxSBbS9cln1BHCqcn9CG/P62/clxcPRGJmRpkHqp77YmuSYGJ2KKOfymruUdyYOnCzHWrb9yR20ObHp0sdJFkMktWIUH4cZTyuSFs41om5c8QEYk9URn/qIT83vf3UVJboqXG1gefv3kXSBCGho7gs3Ctr9oMMuk6W/L9pHYFQm5JRhc4pZGbG2APAoBR0uFYesYw/cZ8AIrme2U5PRrF+ZjQrmDafKEklKngZPXtzaBuljbwDY6sTGjtypCgo0n53xwnCoVn/fkPNIRu29+LjePzvllowvtSmVT1LjIPWIaw==</Q></RSAParameters>";
        public string privateKeyExport = "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";

        //2048
        //public string privateKeySTR => "<?xml version=\"1.0\" encoding=\"utf-16\"?><RSAParameters xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><D>ldcmsYlhourpEe2SCIUk07ftMSZgcdFkfXgkilJou5LG6h7ooUM8Q/F2w8oKQdsRw74Km4FPv9Z0LOclyuOvqVuDmT74jBS9MgRGZrOclqOvhAy9F+sCWwN5MNbtrtZ9SnDX/OV2hAwALoi2e5qwYhWM0jqTcXQOznUbE0XnMZnpToDC5JBFeuoHfFascjS1u7sWpIPc+aqxYZ5OJFrxcUhgToPr1k2vL4YCpkXcJVeUlCAQdwBk5UCwEwLJGIdzxMb/wqWjGfVFdY75+a65VR7B79hN7LnsRJi2PsO82F3nfrQQh1xBk/aZ4ndugxfbnOnshfLQt6sUv0ltIquIAQ==</D><DP>q2UfO6R8w2ghta6wYnCds5wgerjT8NK3/EFme3L2HoQTtwtAziSNtndiixHh6og8uiLzUzKVST5e5mihycFZdmBGTszhwAoNyZAnHx/sLGc5vAapfhh5Z4SFU09OtRMg73l4w7hx+eTsxsDckIMk08LEd5AXr+ahlufnj6rxqNs=</DP><DQ>amt+STCQqE5axx73wcEYCELqNSNGgJ6f62N0nRQuOmoSpm3QI+TEiihqoYqYAhVEsdiWy8j7AAY+kpOyXSYERGfKjNE6Ta/4sb/teJJ8UeuhW8z4CAYzPwHorieymU/mXmLnoZKkK8AhDezM6EurA2zt7wj9s6KPSmkWzTm05yM=</DQ><Exponent>AQAB</Exponent><InverseQ>kqVgymHbQB8xEoZxtQB0lry61eAPoPXnLBfN4MEtf9vfJ60lEZBTa6jujRYjFzyzIdoT7DxJGBecolB1D6iTramv6ZXzk6qlexKHdmcDPwk+9yw47bL9qo4nDiQVWt/9kjvpOgy4oflEUCrFjFVv43e0UdWEzK0fcLe98uYCMSY=</InverseQ><Modulus>wbxtS+ERCCTothgZzvxZqTIbCSY681KJcuRfsHBrYj1tPKKuORxFNT217O7wi4BsHX500N5HcK2D5U9JTZ+mNREI/mWVtl7BAPokvgfGMXS3y/DQWMSobziq7k26237uELfFFFnLhdS1TkRjk83MRDtjbufypYhnxTEEkUxBQAMsxj2EYtEw9k+rcSTfl203Qj5jdECO2LgKGL0Oz7Yb8PT1rM6Q3l3/2TXD1cfpfWA/bRsYYeokgikL+Hn27qFqhFgnuVBB4Tcm3t6mUojfc9wlCXngz1STNClDBMWt+UKg134Mxs1z+dhjEMP8ty3cnIj735CJnppASbNxSF4CNQ==</Modulus><P>zKqjdLLzFWZsRVDb3qAwFReIXEAofsrq3q3Iaa9XCowaYM0y1dD0GKu7VPJVQlMlNc/9o/XVbmbVYmdzEc9Ark9Yhcq007qGz4f+6hrt6tk3MO/RFDhmgZ2q6PSwUZSuEklfid0u2Mo+wRawgCQSaQORwvHZYzNi1VAm1/xi9d8=</P><Q>8lP0en0F+eOwUOwXqp4utaOtNUQfKpJJuEjv4Ok24IYtkDuL67pgLagJseWq4hkpSlzZZCTieC3ibGBJBAPRzexMNzd4Ad7O47qmSHTQWrngT9MP6+ruRAUDjLEVYhGynj/B/XDT5PZtcQrL9246AOghMeYfcIw1F7CrZ56agms=</Q></RSAParameters>";

        //1024
        //public string privateKeySTR => "<?xml version=\"1.0\" encoding=\"utf-16\"?><RSAParameters xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><D>Kel5XOItQVSbnxTr3edk/rbr4qUYLHmBybfW0ttqELCX7S2KqhaeV/zmUUWxftUkthuWsujmLOpT+Dvd3z1k566UHy+xGNrvP26bZ5hIVYE0b+aTX/m+l0TtBUViFwFpxzW3IDPbFhPK141WTm8NIIa8fvm+/4VoBqYwV/sK7Y0=</D><DP>hYcaxBvIsMpSB7IboV0r5O0sCUTHApi22OO5rQqIjtXXfL8JXXE+pMeqeeCCfUCby5E54ASqVA7ZH8SnOZ+7tQ==</DP><DQ>IcgCkLC0syaPzfkaQ2XJF4Dmd5GBfNXMNUqRfZWSwURlWLroxlpoxvZFgBCtLgd9Z4hzFR2Zn29HL/VSJ0JPPw==</DQ><Exponent>AQAB</Exponent><InverseQ>Rr3bto6tS5qZByRFq0cwW6P3RPt1xx9pOziyp7H/XMQ3vPfj6xE7JZfO/fckWQOhF/yg3A0Q9uQX7eYtFUeWFQ==</InverseQ><Modulus>ojcM3wURF2qVhDA997vzVRmqPejZ2YiwgsTCV7C7prh77++rc8fyjcTchQrKgP/6XVh4UeAOXBQmrm8H++/qjep706hSm+ipP+1HbSeEtmRS0eYrAp0plKOKJLL5THx8ZeSWC56lvzvn8U3Q5GUglBL89MBN1HOoBi30SXVZHi0=</Modulus><P>wFrvk12yK0F1j9GPrgdYR1uahehM1yJjyf6BoWutoHFMVFp5MDGtOasdzHMtiIUe9hz/v4cNf3X2VgmPeHK7rw==</P><Q>1+MmossWVrRcFBfe9f2qaFjRtFww/JyyUOaht4hiOiTC8U2MjPkdBEuAPtzB+8Xe+VTEJtwyJwPvTixWfODu4w==</Q></RSAParameters>";

        public RSAParameters publicKey()
        {
            //get a stream from the string
            var sr = new System.IO.StringReader(publicKeySTR);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            return (RSAParameters)xs.Deserialize(sr);
        }
        public RSAParameters privateKey()
        { 
            //get a stream from the string
            var sr = new System.IO.StringReader(privateKeySTR);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            return (RSAParameters)xs.Deserialize(sr);
        }

        public string EncryptString(string text)
        {
            TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
            UTF8Encoding utF8Encoding = new UTF8Encoding();
            byte[] rgbKey = new byte[24]
            {
        (byte) 111,
        (byte) 121,
        (byte) 131,
        (byte) 141,
        (byte) 151,
        (byte) 161,
        (byte) 171,
        (byte) 181,
        (byte) 191,
        (byte) 101,
        (byte) 111,
        (byte) 121,
        (byte) 131,
        (byte) 141,
        (byte) 151,
        (byte) 161,
        (byte) 171,
        (byte) 181,
        (byte) 191,
        (byte) 201,
        (byte) 211,
        (byte) 221,
        (byte) 231,
        (byte) 241
            };
            byte[] rgbIV = new byte[8]
            {
        (byte) 181,
        (byte) 171,
        (byte) 161,
        (byte) 151,
        (byte) 141,
        (byte) 131,
        (byte) 121,
        (byte) 111
            };
            return Convert.ToBase64String(Transform(utF8Encoding.GetBytes(text), cryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV)));
        }

        public string DecryptString(string text)
        {
            TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
            UTF8Encoding utF8Encoding = new UTF8Encoding();
            byte[] rgbKey = new byte[24]
            {
        (byte) 111,
        (byte) 121,
        (byte) 131,
        (byte) 141,
        (byte) 151,
        (byte) 161,
        (byte) 171,
        (byte) 181,
        (byte) 191,
        (byte) 101,
        (byte) 111,
        (byte) 121,
        (byte) 131,
        (byte) 141,
        (byte) 151,
        (byte) 161,
        (byte) 171,
        (byte) 181,
        (byte) 191,
        (byte) 201,
        (byte) 211,
        (byte) 221,
        (byte) 231,
        (byte) 241
            };
            byte[] rgbIV = new byte[8]
            {
        (byte) 181,
        (byte) 171,
        (byte) 161,
        (byte) 151,
        (byte) 141,
        (byte) 131,
        (byte) 121,
        (byte) 111
            };
            byte[] bytes = Transform(Convert.FromBase64String(text), cryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV));
            return utF8Encoding.GetString(bytes);
        }

        public byte[] Transform(byte[] input, ICryptoTransform CryptoTransform)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, CryptoTransform, CryptoStreamMode.Write);
            cryptoStream.Write(input, 0, input.Length);
            cryptoStream.FlushFinalBlock();
            memoryStream.Position = 0L;
            byte[] buffer = new byte[(int)(memoryStream.Length - 1L) + 1];
            memoryStream.Read(buffer, 0, buffer.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return buffer;
        }

        public string EncryptByPrivateKey(string m)
        {
            //we have a private key ... let's get a new csp and load that key
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(privateKey());

            //we need some data to encrypt
            var plainTextData = m;

            //for encryption, always handle bytes...
            var bytesPlainTextData = System.Text.Encoding.UTF8.GetBytes(plainTextData);

            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

            //we might want a string representation of our cypher text... base64 will do
            var cypherText = Convert.ToBase64String(bytesCypherText);
            return cypherText;
        }

        public string DecryptByPrivateKey(string c)
        {
            string cypherText = c;
            //first, get our bytes back from the base64 string ...
            var bytesCypherText = Convert.FromBase64String(cypherText);

            //we want to decrypt, therefore we need a csp and load our private key
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(privateKey());

            //decrypt and strip pkcs#1.5 padding
            //RSAEncryptionPadding rSAEncryptionPadding =RSAEncryptionPadding.Pkcs1;
            //var bytesPlainTextData = csp.Decrypt(bytesCypherText, RSAEncryptionPadding.OaepSHA1);
            var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

            //get our original plainText back...
            var plainTextData = System.Text.Encoding.UTF8.GetString(bytesPlainTextData);
            return plainTextData;
        }

        public string EncryptByPublicKey(string m)
        {
            //we have a public key ... let's get a new csp and load that key
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(publicKey());

            //we need some data to encrypt
            var plainTextData = m;

            //for encryption, always handle bytes...
            var bytesPlainTextData = System.Text.Encoding.UTF8.GetBytes(plainTextData);

            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

            //we might want a string representation of our cypher text... base64 will do
            var cypherText = Convert.ToBase64String(bytesCypherText);
            return cypherText;
        }

        public string DecryptByPublicKey(string c)
        {
            string cypherText = c;
            //first, get our bytes back from the base64 string ...
            var bytesCypherText = Convert.FromBase64String(cypherText);

            //we want to decrypt, therefore we need a csp and load our public key
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(publicKey());

            //decrypt and strip pkcs#1.5 padding
            var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

            //get our original plainText back...
            var plainTextData = System.Text.Encoding.UTF8.GetString(bytesPlainTextData);
            return plainTextData;
        }
    }
}
