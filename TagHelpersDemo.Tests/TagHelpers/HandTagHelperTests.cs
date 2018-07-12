using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpersDemo.TagHelpers;
using Xunit;

namespace TagHelpersDemo.Tests.TagHelpers
{
    public class HandTagHelperTests
    {
        [Fact]
        public void Process_Generates_Expected_Output()
        {
            // ==== Arrange ====
            const string ROOT_HTML_ELEMENT_TAG = "div";

            var context = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                Guid.NewGuid().ToString("N"));

            var output = new TagHelperOutput(ROOT_HTML_ELEMENT_TAG,
                new TagHelperAttributeList(),
                (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            var handTagHelper = new HandTagHelper
            {
                Player = "John"
            };

            // ==== Act ====
            handTagHelper.Process(context, output);

            // ==== Assert ====
            // Compare root HTML elements
            Assert.Equal(ROOT_HTML_ELEMENT_TAG, output.TagName);

            // Compare root HTML elements' class attribute values
            Assert.Equal("row", output.Attributes["class"].Value);

            // Compare to the content of the root HTML element (should be empty, since no cards are defined)
            Assert.Equal(string.Empty, output.Content.GetContent());
        }
    }
}
