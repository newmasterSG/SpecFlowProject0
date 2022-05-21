Feature: Test
  As a userit
  I want to test all main se functionality
  So that I can be sure that site works correctly

@TestCHoosenWord
Scenario: Let's verify that the word "рыба" correctly appears in the first paragraph ("Что такое Lorem Ipsum?")
	Given Go to https://lipsum.com/
	When Switch to Russian language using one of the links
	Then Verify that the text of the first element, which is the first paragraph, contains the word

	@CheckFirstSentenceToLoremEtc
Scenario: Let's verify that default setting result in text starting with Lorem ipsum
	Given Go to https://lipsum.com/
	When Press “Generate Lorem Ipsum
	Then Verify that the first paragraph starts with 'Lorem ipsum dolor sit amet, consectetur adipiscing elit'

@GenerateCorrectSize
Scenario: Let's verify that Lorem Ipsum is generated with correct size
	Given Go to https://www.lipsum.com/
	And Use field word field
	And Input 10 into the number field
	When Press “Generate Lorem Ipsum
	And Verify correct generation for 10
	And Go Back
	And Use field word field
	And Input -1 into the number field
	And Press “Generate Lorem Ipsum
	And Verify correct generation for -1
	And Go Back
	And Use field word field
	And Input 0 into the number field
	And Press “Generate Lorem Ipsum
	And Verify correct generation for 0
	And Go Back
	And Use field word field
	And Input 5 into the number field
	And Press “Generate Lorem Ipsum
	And Verify correct generation for 5
	And Go Back
	And Use field word field
	And Input 20 into the number field
	And Press “Generate Lorem Ipsum
	And Verify correct generation for 20
	And Go Back
	Then Use field bytes
	And Input 3 into the number field
	And Press “Generate Lorem Ipsum
	And Verify correct generation for 3
	And Go Back
	And Use field bytes
	And Input 4 into the number field
	And Press “Generate Lorem Ipsum
	And Verify correct generation for 4

@CheckBox
Scenario: Let's verify the checkbox
	Given Go to https://www.lipsum.com/
	And Uncheck start with Lorem Ipsum checkbox
	When Press “Generate Lorem Ipsum
	Then Verify that result no longer starts with Lorem ipsum

@ContainWord
Scenario: Let's also check that randomly generated text paragraphs contain the word "lorem"
	Given Go to https://www.lipsum.com/
	When Press “Generate Lorem Ipsum
	Then Run the generation 10 times and get the average number of paragraphs containing the word lorem

	