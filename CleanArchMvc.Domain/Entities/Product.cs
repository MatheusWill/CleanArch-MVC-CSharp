using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(
            string name,
            string description,
            decimal price,
            int stock,
            string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(
            int id,
            string name,
            string description,
            decimal price,
            int stock,
            string image)
        {
            DomainExceptionValidation.When(id < 0, "INVALID_ID_VALUE");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(
            string name,
            string description,
            decimal price,
            int stock,
            string image,
            int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(
            string name,
            string description,
            decimal price,
            int stock,
            string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "INVALID_NAME. Name is requered");
            DomainExceptionValidation.When(name.Length < 3, "INVALID_NAME. Too short, minimun 3 character");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "INVALID_DESCRIPTION. Description is requered");
            DomainExceptionValidation.When(description.Length < 5, "INVALID_DESCRIPTION. Too short, minimun 5 character");
            DomainExceptionValidation.When(price < 0, "INVALID_PRICE_VALUE");
            DomainExceptionValidation.When(stock < 0, "INVALID_STOCK_VALUE");
            DomainExceptionValidation.When(image.Length > 250, "INVALID_IMAGE_NAME. Too long, maximum 250 character");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
