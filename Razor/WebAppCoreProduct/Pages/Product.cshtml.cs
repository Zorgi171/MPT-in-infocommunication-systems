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
            MessageRezult = "��� ������ ����� ���������� ������";
        }


        /// <summary>
        /// � ����� ���������� 2 ���������
        /// ����� OnPost ������������ ��������� ������ �� ������� 18%
        /// ����� OnPostDiscount ������������ ��������� ������ � ������������ (���������) �������
        /// ����� OnPostAmount ������������ ����� �� ��������� ���������� ������� 
        /// </summary>
        /// <param name="name">������������ ������</param>
        /// <param name="price">��������� ������ �� 1 �������</param>


        //�������� ���� � �������� ��������
        //���������� POST �������
        //+ ������ ������
        public void OnPost(string name, decimal? price)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }
            //var result = price * (decimal?)0.18;
            //MessageRezult = $"��� ������ {name} � ����� {price} ������ ��������� {result}";
            var result = price * (decimal?)(1 - 0.18);
            MessageRezult = $"��� ������ {name} � ����� {price} � ������ ������ ��������� {result}";
            Product.Price = price;
            Product.Name = name;
        }
        //���������� ������� POST ����� ��������
        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            Product = new Product();
            var result = price * (1 - (decimal?)discont / 100);
            MessageRezult = $"��� ������ {name} � ����� {price} � ������� {discont}% ��������� {result}";
            Product.Price = price;
            Product.Name = name;
        }
        //���������� POST �3
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
            MessageRezult = $"��� ������ {name} � ����� {price} � ���������� {amount} ��������� {result} (������ ���������� {discount * 100}%)";
            Product.Price = price;
            Product.Name = name;
        }


    }
}
