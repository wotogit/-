using System;

namespace Strategy
{
    /// <summary>
    /// 场景：商场根据不同商品采购不用的折扣方式计费
    /// 客户端完全都不用知道具体调用哪一个细节策略去实现，只需要知道DiscountContext即可，这与工厂方法不同之处。
    /// 客户端不用知道业务逻辑
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DiscountContext("打8折");

            var result = context.Price(180m);

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 策略上下文
    /// </summary>
    public class DiscountContext
    {
        DiscountStrategy context;
        //在构造函数中就要实例化指定的策略
        public DiscountContext(string strategy)
        {
            switch (strategy)//这里一般都使用外配置，结构工厂方法
            {
                case "满100减10":
                    context = new StrategyA();
                    break;
                case "打8折":
                    context = new StrategyB();
                    break;
                default:
                    break;
            }
        }
        //这里定义一个与折扣策略基本相同的方法
        public decimal Price(decimal originalPrice)
        {
            if (context != null)
            {
                return context.Price(originalPrice);
            }

            return originalPrice;
        }
    }

    /// <summary>
    /// 折扣策略
    /// </summary>
    public abstract class DiscountStrategy
    {
        /// <summary>
        /// 价格
        /// </summary>
        /// <param name="priginalPrice"></param>
        /// <returns></returns>
        public abstract decimal Price(decimal originalPrice);
    }
    /// <summary>
    /// 满100减10策略
    /// </summary>
    public class StrategyA : DiscountStrategy
    {
        public override decimal Price(decimal originalPrice)
        {
            if (originalPrice >= 100m)
                return originalPrice - 10;

            return originalPrice;
        }
    }
    /// <summary>
    ///打8折
    /// </summary>
    public class StrategyB : DiscountStrategy
    {
        public override decimal Price(decimal originalPrice)
        { 
            return originalPrice*0.8m;
        }
    }
}
