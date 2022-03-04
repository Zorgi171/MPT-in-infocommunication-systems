using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;

namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
        public Product Product { get; set; }
        public string MessageRezult { get; private set; }

        public void OnGet()
        {
            MessageRezult = "Для товара можно определить скидку";
        }


        /// <summary>
        /// С формы отправляем 2 параметра
        /// метод OnPost рассчитывает стоимость товара со скидкой 18%
        /// Метод OnPostDiscount рассчитывает стоимость товара с персональной (введенной) скидкой
        /// Метод OnPostAmount рассчитывает сумму за введенное количество товаров 
        /// </summary>
        /// <param name="name">Наименование товара</param>
        /// <param name="price">Стоимость товара за 1 единицу</param>


        //Отправка цены и названия продукта
        //Обработчик POST запроса
        //+ расчет скидки
        public void OnPost(string name, decimal? price)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            //var result = price * (decimal?)0.18;
            //MessageRezult = $"Для товара {name} с ценой {price} скидка получится {result}";
            var result = price * (decimal?)(1 - 0.18);
            MessageRezult = $"Для товара {name} с ценой {price} с учетом скидки получится {result}";
            Product.Price = price;
            Product.Name = name;
        }
        //Обработчик запроса POST опред сценария
        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            Product = new Product();
            var result = price * (1 - (decimal?)discont / 100);
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discont}% получится {result}";
            Product.Price = price;
            Product.Name = name;
        }
        //Обработчик POST №3
        public void OnPostAmount(string name, decimal? price, decimal amount)
        {
            Product = new Product();
            var discount = 0 * 0.01;
            switch (amount)
            {
                case < 2:
                    break;
                case < 5:
                    discount = 5 * 0.01;
                    break;
                case < 10:
                    discount = 10 * 0.01;
                    break;
                default:
                    discount = 20 * 0.01;
                    break;
            }

            var result = price * (decimal?)amount * (decimal?)(1 - discount);
            MessageRezult = $"Для товара {name} с ценой {price} в количестве {amount} получится {result} (скидка составляет {discount * 100}%)";
            Product.Price = price;
            Product.Name = name;
        }


    }
}
