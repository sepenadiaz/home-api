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
    public class CreditCardServiceTests
    {
        [Fact]
        public async System.Threading.Tasks.Task Add_ReturnsCreatedDTO()
        {
            var mockRepo = new Mock<ICreditCardRepository>();
            var post = new CreditCardPostDTO { Bank = "Bank A", CardBrand = "Visa" };
            var expected = new CreditCardDTO { Id = 1, Bank = "Bank A", CardBrand = "Visa" };

            mockRepo.Setup(r => r.Add(post, It.IsAny<CancellationToken>())).ReturnsAsync(expected);

            var service = new CreditCardService(mockRepo.Object);

            var result = await service.Add(post, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().Be(expected.Id);
            result.Bank.Should().Be(expected.Bank);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetById_ReturnsDTO_WhenExists()
        {
            var mockRepo = new Mock<ICreditCardRepository>();
            var expected = new CreditCardDTO { Id = 2, Bank = "Bank B", CardBrand = "Master" };

            mockRepo.Setup(r => r.GetByFilter(It.Is<Home.Api.Filters.CreditCardFilter>(f => f.Id == 2), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new List<CreditCardDTO> { expected } as IEnumerable<CreditCardDTO>);

            var service = new CreditCardService(mockRepo.Object);

            var result = await service.GetById(2, CancellationToken.None);

            result.Should().NotBeNull();
            result!.Id.Should().Be(expected.Id);
        }
    }
}




