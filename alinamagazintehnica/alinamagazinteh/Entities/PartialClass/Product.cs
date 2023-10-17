using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace alinamagazinteh.Entities
{
    public partial class Product
    {
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        public string CostWithDiscount
        {
            get
            {
                if (Discount == 0)
                {
                    return Cost.ToString();
                }
                else
                {
                    return $"{Cost - Cost*((decimal)Discount/100)}";
                }
            }
        }

        public string VanushieOtzv
        {
            get 
            {
                return $"{Feedback.Where(x => x.ProductId == Id).Count()} отзывов";

            }

        }
    }
}
