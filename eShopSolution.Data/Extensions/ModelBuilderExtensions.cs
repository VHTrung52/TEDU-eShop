using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // seeding data
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig()
                {
                    Key = "HomeTitle",
                    Value = "This is home page of eShopSolution"
                },
                new AppConfig()
                {
                    Key = "HomeKeyword",
                    Value = "This is keyword of eShopSolution"
                },
                new AppConfig()
                {
                    Key = "HomeDescription",
                    Value = "This is description of eShopSolution"
                }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language()
                {
                    Id = "vi",
                    Name = "Tiếng Việt",
                    IsDefault = true
                },
                new Language()
                {
                    Id = "en",
                    Name = "English",
                    IsDefault = false
                }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active,
                }
                );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Áo nam",
                    LanguageId = "vi",
                    SeoAlias = "ao-nam",
                    SeoDescription = "Sản phẩm áo thời trang nam",
                    SeoTitle = ""
                },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Men Shirt",
                    LanguageId = "en",
                    SeoAlias = "men-Shirt",
                    SeoDescription = "The shirt products for men",
                    SeoTitle = ""
                },
                new CategoryTranslation()
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Áo nữ",
                    LanguageId = "vi",
                    SeoAlias = "ao-nu",
                    SeoDescription = "Sản phẩm áo thời trang nữ",
                    SeoTitle = ""
                },
                new CategoryTranslation()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Woman Shirt",
                    LanguageId = "en",
                    SeoAlias = "woman-Shirt",
                    SeoDescription = "The shirt products for woman",
                    SeoTitle = ""
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 10,
                    ViewCount = 0,
                }
                );

            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "Áo nam trắng Việt Tiến",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-so-mi-trang-viet-tien",
                    SeoDescription = "Sản phẩm áo thời trắng Việt Tiến",
                    SeoTitle = "Sản phẩm áo thời trắng Việt Tiến",
                    Details = "Sản phẩm áo thời trắng Việt Tiến",
                    Description = "Sản phẩm áo thời trắng Việt Tiến"
                },
                new ProductTranslation()
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "Viet Tien Men T-Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "viet-tien-men-t-shirt",
                    SeoDescription = "Viet Tien Men T-Shirt",
                    SeoTitle = "Viet Tien Men T-Shirt",
                    Details = "Viet Tien Men T-Shirt",
                    Description = "Viet Tien Men T-Shirt"
                }
                );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory()
                {
                    ProductId = 1,
                    CategoryId = 1,
                });

            var roleId1 = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var roleId2 = new Guid("44CA662A-68E3-410D-85DB-72C4E70E2D48");

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleId1,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"
                },
                new AppRole
                {
                    Id = roleId2,
                    Name = "user",
                    NormalizedName = "user",
                    Description = "User role"
                });

            var hasher = new PasswordHasher<AppUser>();

            var userId1 = new Guid("7C6187F4-1973-4ECE-AA42-F298219BB27D");
            var userId2 = new Guid("A2DEA42F-162E-4CE9-A2D2-F3BFB44AF01D");
            var userId3 = new Guid("5F5D0F29-F012-411A-970E-97835C440947");
            var userId4 = new Guid("7C0E9767-4655-4DF7-940D-FDC462607D46");

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = userId1,
                    UserName = "admin1",
                    NormalizedUserName = "admin1",
                    Email = "tedu.international@gmail.com",
                    NormalizedEmail = "tedu.international@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                    PhoneNumber = 1234567890.ToString(),
                    SecurityStamp = String.Empty,
                    FirstName = "Toan",
                    LastName = "Bach",
                    Dob = new DateTime(2020, 01, 31)
                },
                new AppUser
                {
                    Id = userId2,
                    UserName = "admin2",
                    NormalizedUserName = "admin2",
                    Email = "vhtrung52@gmail.com",
                    NormalizedEmail = "vhtrung52@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    PhoneNumber = 1234567890.ToString(),
                    SecurityStamp = String.Empty,
                    FirstName = "Hoang",
                    LastName = "Trung",
                    Dob = new DateTime(2020, 01, 31)
                },
                new AppUser
                {
                    Id = userId3,
                    UserName = "user1",
                    NormalizedUserName = "user1",
                    Email = "tedu.international@gmail.com",
                    NormalizedEmail = "tedu.international@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                    PhoneNumber = 1234567890.ToString(),
                    SecurityStamp = String.Empty,
                    FirstName = "Toan",
                    LastName = "Bach",
                    Dob = new DateTime(2020, 01, 31)
                },
                new AppUser
                {
                    Id = userId4,
                    UserName = "user2",
                    NormalizedUserName = "user2",
                    Email = "vhtrung52@gmail.com",
                    NormalizedEmail = "vhtrung52@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    PhoneNumber = 1234567890.ToString(),
                    SecurityStamp = String.Empty,
                    FirstName = "Hoang",
                    LastName = "Trung",
                    Dob = new DateTime(2020, 01, 31)
                }
                );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId1,
                    UserId = userId1
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId1,
                    UserId = userId2
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId2,
                    UserId = userId3
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId2,
                    UserId = userId4
                }
                );
        }
    }
}