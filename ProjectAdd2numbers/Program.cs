using System;
using System.Text;

public class MyBigNumber
{
    public static int[] LayDaySo(string pDaySo, int maxLength)//thêm 0 vào đầu dãy số nếu maxlength bé hơn số còn lại
    {
        int[] daySo = new int[maxLength];
        for (int i = 0; i < pDaySo.Length; i++)
        {   //4 (là maxlength do stn1 có 4 số) - 3(là length của stn2) + 0 = 1 (08) phần thiếu ở phần tử 0 sẽ được thay số 0 vào
            //4 (là maxlength do stn1 có 4 số) - 3(là length của stn2) + 1 = 2 (089)
            //4 (là maxlength do stn1 có 4 số) - 3(là length của stn2) + 2 = 3 (0897)

            //ví dụ stn1 = 12345 có maxlength là 5 và stn2 là 897 có length là 3
            //5 - 3 + 0 = 2 do bắt đầu từ 8 nên 2 phần tử trước đó được thay bằng số 0 (008)

            daySo[maxLength - pDaySo.Length + i] = int.Parse(pDaySo[i].ToString());
        }
        return daySo;
    }
    public static String sum(String stn1, String stn2)
    { 

        int maxLength = stn1.Length > stn2.Length ?
            stn1.Length : stn2.Length;

        //chuyển thành chuỗi số
        int[] daychuSoThuNhat = LayDaySo(stn1, maxLength);
        int[] daychuSoThuHai = LayDaySo(stn2, maxLength);


        int[] daychuSoKetQua = new int[maxLength];
        int nho = 0, kq;
       
        for (int i = maxLength - 1; i > -1; i--)
        { //maxLength là 4 - 1 còn 3 -> trong chuỗi stn1 ở kiểu mảng bắt đầu từ 0 1 2 3 -> lấy số cuối cùng là 4.
                                                                              //1 2 3 4        
            kq = daychuSoThuNhat[i] + daychuSoThuHai[i] + nho;
            daychuSoKetQua[i] = kq % 10; //kq % 10 là lấy số cuối cùng của daychuSoKetQua vd: 13 % 10 = 3
            nho = kq / 10;// kq / 10 là lấy số đầu tiên vd: 13 / 10 = 1
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Lấy {0} cộng với {1} được {2} lưu {3} vào kết quả và nhớ {4} cộng tiếp với nhớ {5} -> kết quả mới: {6}", daychuSoThuNhat[i], daychuSoThuHai[i], kq, daychuSoKetQua[i], nho, nho, string.Join("", daychuSoKetQua));

        }
        return "";
    }
}
public class HelloWorld
{
    public static void Main(string[] args)
    {
        MyBigNumber.sum("1234","897");
    }
}