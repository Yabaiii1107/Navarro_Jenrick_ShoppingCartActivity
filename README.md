# Navarro_Jenrick_ShoppingCartActivity

**AI Usage in This Project**

AI was used in this project to help improve and debug the C# shopping cart program. The main parts where AI was used were in creating the **Product** and **CartItem** classes, organizing the cart system using arrays, checking product stock before adding items to the cart, and generating the receipt with discounts and updated stock. 

AI was used because some parts of the program, especially the cart array and stock validation, were difficult to organize correctly. AI helped explain how to store multiple products in a **CartItem[]** array, how to prevent the cart from exceeding its limit of 5 items, and how to update stock after a product is purchased. It was also used to identify and fix errors in loops and conditions. 

Prompts I used in this project:

* “How can I make my cart limiter use only an array in C#?”
* “How do I add products to a cart array without using a List?”
* “Why is my cart showing duplicate products instead of increasing the quantity?”
* “How can I calculate subtotal, grand total, and apply discounts in a receipt system?”

After using AI, these are the improvements I've made:

* The cart was changed to use **CartItem[] cart = new CartItem[5];** instead of using **List<CartItem>**.
* A check was added so that if the same product is selected again, the quantity and subtotal increase instead of creating another cart entry.
* The receipt and updated stock display were organized to make the output easier to read.
* A 10% discount feature was added when the total reaches ₱5000 or more.

