﻿using AutoMapper;
using NLayerMovie.BLL.DTO;
using NLayerMovie.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerMovie.WEB.Util
{
    public class MapperModule
    {
        public static IEnumerable<CommentsGetViewModel> GetCommentsDTO_To_CommentsGetViewModel(IEnumerable<GetCommentsDTO> commentsDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GetCommentsDTO, CommentsGetViewModel>()).CreateMapper();
            IEnumerable<CommentsGetViewModel> commentsGetViewModel = mapper.Map<IEnumerable<GetCommentsDTO>, IEnumerable<CommentsGetViewModel>>(commentsDTO);
            
            return commentsGetViewModel;

        }
    }
}