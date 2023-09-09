
using AutoMapper;
using ShopExample.Model.Model;
using ShopExample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopExample.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static Mapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
            });

            var mapper = new Mapper(config);

            return mapper;
        }
    }
}