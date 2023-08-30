using StringCalculator.Shared.Model;

namespace StringCalculator.Tests.Model
{
    public class CalculatorAdd
    {
        private readonly Calculator _calculator;

        public CalculatorAdd()
        {
                _calculator = new Calculator();
        }
        
        [Fact]
        public void ReturnZeroGivenEmptyStrings()
        {
            // Arrange
            //var calculator = new Calculator();

            // Act
            int result = _calculator.Add(new string[] { "" });

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnOneGivenOne()
        {
            // Arrange
            //var calculator = new Calculator();

            // Act
            int result = _calculator.Add(new string[] { "1" });

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void ReturnTwoGivenTwo()
        {
            // Arrange
            //var calculator = new Calculator();

            // Act
            int result = _calculator.Add(new string[] {"2"});

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void ReturnNumbersSumGivenAnyNumbers()
        {
            // Arrange
            //var calculator = new Calculator();

            // Act
            int result = _calculator.Add(new string[] {"1", "2"});

            // Assert
            Assert.Equal(3, result);
        }
    }
}
