using ShopExample.Model.Model;
using ShopExample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopExample.Web.Infrastructure.Extensions
{
    public static class EntityExtension
    {
        /// <summary>
        /// trong c# căn bản Extension method có 3 nguyên tắc
        ///  1. Phương thức, class phải static
        ///  2. Chỗ nào sử dụng phương thức cho class được chỉ định phải được thhif phải được using namespace của lớp chứa EM (extension method)
        ///  3. 
        /// </summary>
        /// <param name="pc">Tham số đầu tiên chứa từ khóa this giúp chỉ định đối tượng của tham số đầu tiên ảnh hưởng đến phương thức được add vào đối tượng này</param>
        /// <param name="pcVM"></param>
        public static void UpdatePostCategory(this PostCategory pc, PostCategoryViewModel pcVM)
        {
            pc.ID = pcVM.ID;
            pc.Name = pcVM.Name;
            pc.Description = pcVM.Description;
            pc.Alias = pcVM.Alias;
            pc.ParentID = pcVM.ParentID;
            pc.Image = pcVM.Image;
            pc.DisplayOrder = pcVM.DisplayOrder;
            pc.HomeFlag = pcVM.HomeFlag;
            pc.CreatedDate = pcVM.CreatedDate;
            pc.CreatedBy = pcVM.CreatedBy;
            pc.ModifiedDate = pcVM.ModifiedDate;
            pc.ModifiedBy = pcVM.ModifiedBy;
            pc.MetaKeyWord = pcVM.MetaKeyWord;
            pc.MetaDescription = pcVM.MetaDescription;
            pc.Status = pcVM.Status;
    }

        public static void UpdatePost(this Post p, PostViewModel pVM)
        {
            p.ID = pVM.ID;
            p.Name = pVM.Name;
            p.Description = pVM.Description;
            p.Alias = pVM.Alias;
            p.Contents = pVM.Contents;
            p.CategoryID = pVM.CategoryID;
            p.Image = pVM.Image;
            p.ViewCount = pVM.ViewCount;
            p.HomeFlag = pVM.HomeFlag;
            p.HotFlag = pVM.HotFlag;
            p.CreatedDate = pVM.CreatedDate;
            p.CreatedBy = pVM.CreatedBy;
            p.ModifiedDate = pVM.ModifiedDate;
            p.ModifiedBy = pVM.ModifiedBy;
            p.MetaKeyWord = pVM.MetaKeyWord;
            p.MetaDescription = pVM.MetaDescription;
            p.Status = pVM.Status;
        }
    }
}