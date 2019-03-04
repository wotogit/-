using System;

namespace Factory
{
    /// <summary>
    /// 计算两个数
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var cal = CalculateFactory.CreateCalculate("+");
            cal.NumberA = 10;
            cal.NumberB = 20;

            var result = cal.CalculateResult();
            Console.Write(result);
            
            Console.ReadLine();
        }
    }
    /// <summary>
    /// 创建实例工厂
    /// </summary>
    public static class CalculateFactory
    {
        public  static CalculateBase CreateCalculate(string symbolStr)
        {
            CalculateBase cal=null;

            //这里一般都是通过配置文件，反射手段来解决新增运算符时需要重新改代码
            switch (symbolStr)
            {
                case "+":
                    cal = new AdditionCalcu();
                    break;
                case "-":
                    cal = new SubtractionCalcu();
                    break;
                default:
                    break;
            }

            return cal;
        }
    }

    /// <summary>
    /// 算术基类
    /// </summary>
    public abstract class CalculateBase
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }

        /// <summary>
        /// 计算
        /// </summary>
        /// <returns></returns>
        public abstract double CalculateResult();
    }

    /// <summary>
    /// 加法运算
    /// </summary>
    public class AdditionCalcu : CalculateBase
    {
        public override double CalculateResult()
        {
            return NumberA + NumberB;
        }
    }
    /// <summary>
    /// 减法
    /// </summary>
    public class SubtractionCalcu : CalculateBase
    {
        public override double CalculateResult()
        {
            return NumberA - NumberB;
        }
    }
}
