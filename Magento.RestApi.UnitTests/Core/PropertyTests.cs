﻿using System.Collections.Generic;
using Magento.RestApi.Core;
using Xunit;

namespace Magento.RestApi.UnitTests.Core
{
    public class WhenConstructingIntProperty
    {
        [Fact]
        public void ForIntShouldHaveDefaults()
        {
            // arrange
            Property<int> property = null;

            // act
            property = new Property<int>();

            // assert
            Assert.Equal(0, property.InitialValue);
            Assert.Equal(0, property.Value);
            Assert.False(property.HasChanged());
        }

        [Fact]
        public void ForStringShouldHaveDefaults()
        {
            // arrange
            Property<string> property = null;

            // act
            property = new Property<string>();

            // assert
            Assert.Equal(null, property.InitialValue);
            Assert.Equal(null, property.Value);
            Assert.False(property.HasChanged());
        }
    }
    
    public class WhenChangingValueOnIntProperty
    {
        [Fact]
        public void HasChangedShouldBeTrue()
        {
            // arrange
            var property = new Property<int>();

            // act
            property.Value = 1;

            // assert
            Assert.True(property.HasChanged());
            Assert.Equal(0, property.InitialValue);
            Assert.Equal(1, property.Value);
        }

        [Fact]
        public void HasChangedShouldBeFalseAfterInitialValueIsSet()
        {
            // arrange
            var property = new Property<int>();

            // act
            property.Value = 1;
            property.SetValueAsInitial();

            // assert
            Assert.False(property.HasChanged());
            Assert.Equal(1, property.InitialValue);
            Assert.Equal(1, property.Value);
        }

        [Fact]
        public void HasChangedShouldBeTrueAfterInitialValueIsSetAndChanged()
        {
            // arrange
            var property = new Property<int>();

            // act
            property.Value = 1;
            property.SetValueAsInitial();
            property.Value = 2;

            // assert
            Assert.True(property.HasChanged());
            Assert.Equal(1, property.InitialValue);
            Assert.Equal(2, property.Value);
        }
    }
    
    public class WhenChangingValueOnListProperty
    {
        [Fact]
        public void HasChangedShouldBeTrue()
        {
            // arrange
            var property = new Property<List<int>>();

            // act
            property.Value = new List<int>();

            // assert
            Assert.True(property.HasChanged());
            Assert.Null(property.InitialValue);
            Assert.Equal(0, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeFalseAfterInitialValueIsSet()
        {
            // arrange
            var property = new Property<List<int>>();

            // act
            property.Value = new List<int>();
            property.SetValueAsInitial();

            // assert
            Assert.False(property.HasChanged());
            Assert.Equal(0, property.InitialValue.Count);
            Assert.Equal(0, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeTrueAfterInitialValueIsSetAndChanged()
        {
            // arrange
            var property = new Property<List<int>>();

            // act
            property.Value = new List<int>();
            property.SetValueAsInitial();
            property.Value = new List<int>{1};

            // assert
            Assert.True(property.HasChanged());
            Assert.Equal(0, property.InitialValue.Count);
            Assert.Equal(1, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeFalseAfterInitialValueIsSetAndSameItemIsAdded()
        {
            // arrange
            var property = new Property<List<int>>();

            // act
            property.Value = new List<int> { 1 };
            property.SetValueAsInitial();
            property.Value = new List<int> { 1 };

            // assert
            Assert.False(property.HasChanged());
            Assert.Equal(1, property.InitialValue.Count);
            Assert.Equal(1, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeTrueAfterInitialValueIsSetAndOtherItemIsAdded()
        {
            // arrange
            var property = new Property<List<int>>();

            // act
            property.Value = new List<int> { 1 };
            property.SetValueAsInitial();
            property.Value = new List<int> { 2 };

            // assert
            Assert.True(property.HasChanged());
            Assert.Equal(1, property.InitialValue.Count);
            Assert.Equal(1, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeTrueAfterInitialValueIsSetAndItemIsChanged()
        {
            // arrange
            var property = new Property<List<int>>();

            // act
            property.Value = new List<int> { 1 };
            property.SetValueAsInitial();
            property.Value[0] = 2;

            // assert
            Assert.True(property.HasChanged());
            Assert.Equal(1, property.InitialValue.Count);
            Assert.Equal(1, property.InitialValue[0]);
            Assert.Equal(1, property.Value.Count);
            Assert.Equal(2, property.Value[0]);
        }
    }

    public class WhenChangingValueOnDictionaryProperty
    {
        [Fact]
        public void HasChangedShouldBeTrue()
        {
            // arrange
            var property = new Property<Dictionary<string, string>>();

            // act
            property.Value = new Dictionary<string, string>();

            // assert
            Assert.True(property.HasChanged());
            Assert.Null(property.InitialValue);
            Assert.Equal(0, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeFalseAfterInitialValueIsSet()
        {
            // arrange
            var property = new Property<Dictionary<string, string>>();

            // act
            property.Value = new Dictionary<string, string>();
            property.SetValueAsInitial();

            // assert
            Assert.False(property.HasChanged());
            Assert.Equal(0, property.InitialValue.Count);
            Assert.Equal(0, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeFalseAfterSetToNull()
        {
            // arrange
            var property = new Property<Dictionary<string, string>>();
            property.Value = new Dictionary<string, string>();
            property.SetValueAsInitial();

            // act
            property.Value = null;

            // assert
            Assert.False(property.HasChanged());
        }

        [Fact]
        public void HasChangedShouldBeTrueAfterInitialValueIsSetAndChanged()
        {
            // arrange
            var property = new Property<Dictionary<string, string>>();

            // act
            property.Value = new Dictionary<string, string>();
            property.SetValueAsInitial();
            property.Value = new Dictionary<string, string> { {"key", "value"} };

            // assert
            Assert.True(property.HasChanged());
            Assert.Equal(0, property.InitialValue.Count);
            Assert.Equal(1, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeFalseAfterInitialValueIsSetAndSameItemIsAdded()
        {
            // arrange
            var property = new Property<Dictionary<string, string>>();

            // act
            property.Value = new Dictionary<string, string> { { "key", "value" } };
            property.SetValueAsInitial();
            property.Value = new Dictionary<string, string> { { "key", "value" } };

            // assert
            Assert.False(property.HasChanged());
            Assert.Equal(1, property.InitialValue.Count);
            Assert.Equal(1, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeTrueAfterInitialValueIsSetAndOtherItemIsAdded()
        {
            // arrange
            var property = new Property<Dictionary<string, string>>();

            // act
            property.Value = new Dictionary<string, string> { { "key", "value" } };
            property.SetValueAsInitial();
            property.Value = new Dictionary<string, string> { { "another_key", "value" } };

            // assert
            Assert.True(property.HasChanged());
            Assert.Equal(1, property.InitialValue.Count);
            Assert.Equal(1, property.Value.Count);
        }

        [Fact]
        public void HasChangedShouldBeTrueAfterInitialValueIsSetAndItemIsChanged()
        {
            // arrange
            var property = new Property<Dictionary<string, string>>();

            // act
            property.Value = new Dictionary<string, string> { { "key", "value" } };
            property.SetValueAsInitial();
            property.Value["key"] = "another_value";

            // assert
            Assert.True(property.HasChanged());
            Assert.Equal(1, property.InitialValue.Count);
            Assert.Equal(1, property.Value.Count);
        }
    }
}
