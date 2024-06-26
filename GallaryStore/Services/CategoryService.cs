﻿using GallaryStore.DTOs.category;
using GallaryStore.DTOs.product;
using GallaryStore.Models;
using GallaryStore.UnitOfWork;

namespace GallaryStore.Services
{
    public class CategoryService
    {
        public unitOfWork<Category> unit;
        public CategoryService(unitOfWork<Category> unit)
        {
            this.unit = unit;
        }

        public List<CategoryDTO> GetAll()
        {
            return unit.Repository.GetAll().Select(p => new CategoryDTO(p.id,p.name)).ToList();
        }
        public CategoryDTO GetById(int id)
        {

            Category? p = unit.Repository.GetById(id);
            if (p == null)
                return null;
            return new CategoryDTO(p.id, p.name);
        }

        public void Update(CategoryDTO Category)
        {
            Category p = new Category()
            {
                id = Category.id,
                name= Category.name,
                

            };
            unit.Repository.update(p);
            unit.savechanges();
        }
        public void Delete(int id)
        {
            Category Category = unit.Repository.GetById(id);
            unit.Repository.delete(Category);
            unit.savechanges();
        }
        public void Add(AddCategoryDTO Category)
        {
            Category p = new Category()
            {
                id = 0,
                name = Category.name,
            };
            unit.Repository.add(p);
            unit.savechanges();
        }
        public List<ProductDTO> getCategoryProducts(int categoryId)
        {
            var products = unit.Repository.getElement(c => c.id == categoryId, "products").products;

            List<ProductDTO> productDTOs= new List<ProductDTO>();
            foreach (var item in products)
            {
                ProductDTO product = new ProductDTO(item.id, item.name, item.description, item.price, item.quantity, item.rate, item.img, item.categoryID);
                productDTOs.Add(product);
            }
            return productDTOs;

        }
    }
}
