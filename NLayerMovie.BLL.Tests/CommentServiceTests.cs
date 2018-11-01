using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NLayerMovie.BLL.DTO;
using NLayerMovie.BLL.Services;
using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Interfaces;

namespace NLayerMovie.BLL.Tests
{
    [TestClass]
    public class CommentServiceTests
    {
        [TestMethod]
        public void PostComment_CreateAndSaveComment_Void()
        {
            // arrange
            var mock_IUnitOfWork = new Mock<IUnitOfWork>();
            var mock_ICommentRepository = new Mock<ICommentRepository<Comment>>();
            mock_IUnitOfWork.Setup(a => a.Comments).Returns(mock_ICommentRepository.Object);
           
            CommentDTO commentDTO = new CommentDTO();
            CommentService commentService = new CommentService(mock_IUnitOfWork.Object);
            // act
            commentService.PostComment(commentDTO);
            // assert           
            mock_ICommentRepository.Verify(a => a.Create(It.IsAny<Comment>()));
            mock_IUnitOfWork.Verify(a => a.Save());
        }
    }
}
