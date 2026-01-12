using System.Collections.Generic;
using System.Threading;
using Home.Api.DTOs;
using Home.Api.Repositories.IRepositories;
using Home.Api.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace Home.Api.UnitTests
{
    public class CreditCardServiceMoreTests
    {
        [Fact]
        public async System.Threading.Tasks.Task Update_ReturnsNull_WhenNotFound()
        {
            var mockRepo = new Mock<ICreditCardRepository>();
            var post = new CreditCardPostDTO { Bank = "X", CardBrand = "Y" };

            mockRepo.Setup(r => r.Update(99, post, It.IsAny<CancellationToken>())).ReturnsAsync((CreditCardDTO?)null);

            var service = new CreditCardService(mockRepo.Object);

            var result = await service.Update(99, post, CancellationToken.None);

            result.Should().BeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task Delete_ReturnsFalse_WhenNotFound()
        {
            var mockRepo = new Mock<ICreditCardRepository>();
            mockRepo.Setup(r => r.Delete(55, It.IsAny<CancellationToken>())).ReturnsAsync(false);

            var service = new CreditCardService(mockRepo.Object);

            var result = await service.Delete(55, CancellationToken.None);

            result.Should().BeFalse();
        }
    }
}




