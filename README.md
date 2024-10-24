# Math-For-Strings
Have you ever wanted to math operations with two REALLY big numbers? But then the numbers are so big that they can't be stored as an interger or even an unsigned interger. Well now you can, using this repository. Better yet, you can do this in ANY base. Binary, Base 10, Base 64, you name it.

## C#
So far there are two C# folders than can be opened with visual studio. Addition and Subtraction. In each Program.cs there would be a function called 'Addition' or 'Subtraction' respectively. Each function takes in two strings, performs the related mathematical function, and returns a string.

## Other Languages
The priority languages to be added are Python and Javascript.

## Goal for the Project
Eventually you should be able to call a function like so...
```javascript
Solve("3*(5+8)^2-4"); // returns 503
```
But imagine that with REALLY big numbers.
So once the individual mathematical operations are built, the next step would be wrap them all up in a library.

## How to Contribute
I'd appreciate your contributions! 
- You can work on translating to other languages, however if you do, please don't rewrite the algorithm. Just translate to another language.
- Make it more effecient. Do you see a for loop that's not needed? Fix it!
- Work on other mathematical operations. Multiplication, Division, and Exponents still need built! See the next section for constraints...
- Make it consistent! I wrote Addition and Subtraction at two very different times, so the code is pretty different.

## How NOT to Contribute
- All algorithms need to be vocab dependent. For instance, each function relies on a vocab variable. In Base 10 this happens to be "0123456789". But if I decided that I want the number 0 to be represented by 'a', then 'a' + 5 should still equal 5. This is how these functions support other bases
- No A.I. generated content. If you contribute, a human has to have written the code. Of course A.I. is a powerful learning tool, and can help you learn and fix bugs along the way, but I won't accept contributions created by A.I.

## License
[MIT](https://choosealicense.com/licenses/mit/)
