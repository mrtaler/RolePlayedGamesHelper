using AutoFixture;
using Moq;
using RolePlayedGamesHelper.Cqrs.Kledex.Exceptions;
using RolePlayedGamesHelper.Cqrs.Kledex.UnitTests.Fakes;
using RolePlayedGamesHelper.Cqrs.Kledex.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RolePlayedGamesHelper.Cqrs.Kledex.UnitTests
{
  public class ValidationServiceTests
  {
    private IValidationService _sut;
    private Mock<IValidationProvider> _validationProviderMock;
    private CreateAggregate _createAggregate;
    private ValidationResponse _validationResponse;


    public ValidationServiceTests()
    {
      _createAggregate = new Fixture().Create<CreateAggregate>();
      _validationResponse = new Fixture().Build<ValidationResponse>()
          .With(x => x.Errors, new List<ValidationError>())
          .Create();

      _validationProviderMock = new Mock<IValidationProvider>();
      _validationProviderMock
          .Setup(x => x.ValidateAsync(_createAggregate))
          .ReturnsAsync(_validationResponse);
      _validationProviderMock
          .Setup(x => x.Validate(_createAggregate))
          .Returns(_validationResponse);

      _sut = new ValidationService(_validationProviderMock.Object);
    }

    [Fact]
    public void ValidateAsync_ThrowsException_WhenCommandIsNull()
    {
      _createAggregate = null;
      Assert.ThrowsAsync<ArgumentNullException>(async () => await _sut.ValidateAsync(_createAggregate));
    }

    [Fact]
    public void Validate_ThrowsException_WhenCommandIsNull()
    {
      _createAggregate = null;
      Assert.ThrowsAsync<ArgumentNullException>(async () => await _sut.ValidateAsync(_createAggregate));
    }

    [Fact]
    public async Task ValidateAsync_CallsProvider()
    {
      await _sut.ValidateAsync(_createAggregate);
      _validationProviderMock.Verify(x => x.ValidateAsync(_createAggregate), Times.Once);
    }

    [Fact]
    public void Validate_CallsProvider()
    {
      _sut.Validate(_createAggregate);
      _validationProviderMock.Verify(x => x.Validate(_createAggregate), Times.Once);
    }

    [Fact]
    public void ValidateAsync_ThrowsException_WhenValidationFails()
    {
      _validationResponse = new Fixture().Build<ValidationResponse>()
          .With(x => x.Errors, new List<ValidationError>
          {
                    new ValidationError
                    {
                        PropertyName = "Something",
                        ErrorMessage = "Blah blah blah..."
                    }
          })
          .Create();

      _validationProviderMock
          .Setup(x => x.ValidateAsync(_createAggregate))
          .ReturnsAsync(_validationResponse);

      _sut = new ValidationService(_validationProviderMock.Object);

      Assert.ThrowsAsync<ValidationException>(async () => await _sut.ValidateAsync(_createAggregate));
    }

    [Fact]
    public void Validate_ThrowsException_WhenValidationFails()
    {
      _validationResponse = new Fixture().Build<ValidationResponse>()
          .With(x => x.Errors, new List<ValidationError>
          {
                    new ValidationError
                    {
                        PropertyName = "Something",
                        ErrorMessage = "Blah blah blah..."
                    }
          })
          .Create();

      _validationProviderMock
          .Setup(x => x.Validate(_createAggregate))
          .Returns(_validationResponse);

      _sut = new ValidationService(_validationProviderMock.Object);

      Assert.Throws<ValidationException>(() => _sut.Validate(_createAggregate));
    }
  }
}
