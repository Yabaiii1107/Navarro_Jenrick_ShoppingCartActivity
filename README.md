# Navarro_Jenrick_ShoppingCartActivity

**AI Usage in This Project**

This project was primarily developed through my own understanding of C# fundamentals, with occasional use of AI as a learning aid. Instead of relying on AI to generate full solutions, I used it to clarify concepts, debug issues, and improve specific parts of my code.

Prompts I used in this project:

* “Why doesn’t my loop return to the main menu after checkout?”
* “How can I properly handle user input validation in C#?”
* “What’s the correct way to update stock when modifying cart items?”
* “Why are my variables showing errors after restructuring my code?”
* “How can I format my product array into table form?”

After using AI, these are the improvements I've made:

* Loop control and program flow (do-while, switch)
* Input validation and avoiding runtime errors
* Managed arrays and object references
* Structuring a console-based system cleanly
* Clearer and more structured console output formatting

**Features Of My Project**
This project is a console-based shopping cart system built in C#. It simulates how a simple store works—from viewing products to checking out.

**Product Display**
Shows a list of available products with:
    * ID, name, category, price, and stock
*Stock updates automatically when items are added or removed

**Add to Cart**
* Users can add items using the product ID
* Allows input of quantity with stock checking
* Prevents adding more than available stock
* Option to keep adding multiple items

**Cart System**
* View all items currently in the cart
* Shows quantity, price, and subtotal per item
* Remove specific items from the cart
* Update item quantity with automatic stock adjustment
* Clear the entire cart with confirmation

**Search Features**
* Search by name
    * Finds products even with partial input
*Search by category
    * Food
    * Clothing
    * School Supplies
 

**Checkout**
* Displays all selected items before purchase
Calculates:
   * Total amount
   * Discount (10% if total is ₱5000 or more)
   * Final total
* Accepts payment and checks if it's enough
* Calculates change automatically

**Receipt**
* Prints a simple receipt after checkout
Includes:
  * Receipt number
  * Date and time
  * Items purchased
  * Payment details
 
**Order History**
* Keeps track of completed orders
* Shows receipt number, total, and date

**Low Stock Alert**
* After checkout, the system checks product stock
Alerts if items are:
  * Low in stock (5 or below)
  * Out of stock

**Repeat Shopping**
* After checkout, user can choose to shop again
* Product list refreshes with updated stock
* User can exit anytime

**Input Validation**
* Handles invalid inputs (letters instead of numbers, wrong choices, etc.)
* Prevents crashes and keeps the program running properly
