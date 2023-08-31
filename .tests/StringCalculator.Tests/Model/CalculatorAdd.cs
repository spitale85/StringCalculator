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
            // Act
            int result = _calculator.Add("");

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnOneGivenOne()
        {
            // Act
            int result = _calculator.Add("1");

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void ReturnTwoGivenTwo()
        {
            // Act
            int result = _calculator.Add("2");

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void ReturnNumbersSumGivenAnyNumbersWithCommas()
        {
            // Act
            int result = _calculator.Add("1,2,3");

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void ReturnNumbersSumGivenAnyNumbersWithCommasAndNewLines()
        {
            // Act
            int result = _calculator.Add("1\n2,3");

            // Assert
            Assert.Equal(6, result);
        }

        [InlineData("//;\n1;2", 3)]
        [InlineData("//[|||]\n1|||2|||3", 6)]
        [InlineData("//[|][%]\n1|2%3", 6)]
        [InlineData("//[||][%%%]\n1||2%%%3", 6)]
        [Theory]
        public void ReturnNumbersSumGivenAnyNumberWithCustomDelimiter(string numbers, int expectedResult)
        {
            // Act
            int result = _calculator.Add(numbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData("-1,2","Negatives not allowed: -1")]
        [InlineData("2,-4,3,-5","Negatives not allowed: -4,-5")]
        [Theory]
        public void ThrowArgumentExceptionGivenAnyNegativeNumbers(string numbers, string expectedException)
        {
            // Act
            var exception = Assert.Throws<Exception>(() => _calculator.Add(numbers));

            // Assert
            Assert .Equal(expectedException, exception.Message);
        }

        [Fact]
        public void ReturnsNumbersSumSkippingAnyGreaterThan1000GivenAnyNumbers()
        {
            // Act
            int result = _calculator.Add("1001,2");

            // Assert
            Assert.Equal(2, result);
        }
    }
}
