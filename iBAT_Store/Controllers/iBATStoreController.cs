using iBAT_Store.Model.Login;
using iBAT_Store.Model.Orders;
using iBAT_Store.Model.Products;
using iBAT_Store.Model.Profile;
using iBAT_Store.Model.SignUp;
using iBAT_Store_Business_Layer;
using iBAT_Store_DataAccess_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace iBAT_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class iBATStoreController : ControllerBase
    {


        [HttpPost("Account/SignInByUsernameAndPassword", Name = "SignInByUsernameAndPasswor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SignInByUsernameAndPassword([FromBody] clsSignInByUsernameAndPasswordRequestDTO requestDTO)
        {
          
            if(String.IsNullOrEmpty(requestDTO.username) || String.IsNullOrEmpty(requestDTO.password))
            {
                return BadRequest("Username and password are empty");
            }

            if(!clsUser.doesUsernameExist(new clsUserDTO { username = requestDTO.username }))
            {
                return Unauthorized("Username does not exist");
            }

            if(!clsUser.signInByUsernameAndPassword(new clsUserDTO { username = requestDTO.username, password = requestDTO.password }))
            {
                return Unauthorized("Incorrect user name or password");
            }


            clsUser user = clsUser.getUserByUsername(new clsUserDTO { username = requestDTO.username });
            clsPerson person = clsPerson.getPersonByPersonID(new clsPersonDTO { personID = user.personID});
            clsAccount account = clsAccount.getAccountByUserID(new clsUserDTO { userID = user.userID });

            List<clsSignInByUsernameAndPasswordResponseDTO> list = new List<clsSignInByUsernameAndPasswordResponseDTO>();
            list.Add(new clsSignInByUsernameAndPasswordResponseDTO
            {
                userID = user.userID,
                accountID = account.accountID,
                firstName = person.firstName ,
                lastName = person.lastName,

            });

            return Ok(list);                      
                    
        }


        [HttpPost("Account/SignUp", Name = "SignUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult SignUp([FromBody] clsSignUpRequestDTO requestDTO)
        {

            if (string.IsNullOrWhiteSpace(requestDTO.username) || string.IsNullOrWhiteSpace(requestDTO.password))
            {
                return BadRequest("Username and password are required.");
            }

    
            if (clsUser.doesUsernameExist(new clsUserDTO { username = requestDTO.username }))
            {
                return Conflict("Username is already taken.");
            }

         
            if (string.IsNullOrWhiteSpace(requestDTO.firstName) ||
                string.IsNullOrWhiteSpace(requestDTO.email) ||
                string.IsNullOrWhiteSpace(requestDTO.phoneNumber))
            {
                return BadRequest("Missing required personal information.");
            }



            clsPersonDTO personDTO = new clsPersonDTO { firstName = requestDTO.firstName , secondName = requestDTO.secondName , thirdName = requestDTO.thirdName , lastName = requestDTO.lastName , phoneNumber = requestDTO.phoneNumber , email = requestDTO.email  , gedner = requestDTO.gender};
            clsUserDTO userDTO = new clsUserDTO { username = requestDTO.username, password = requestDTO .password };

            bool isSignedUpSuccessfully = clsUser.signUp(personDTO,userDTO);

            List<clsSignUpResponseDTO> list = new List<clsSignUpResponseDTO>();
            list.Add(new clsSignUpResponseDTO { isSucceed = isSignedUpSuccessfully});

            return Ok(list);

        }




        [HttpGet("Products/GetAllInventoryProducts", Name = "GetAllInventoryProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllInventoryProducts()
        {
            List <clsGetAllInventoryProductsResponseDTO> list = new List <clsGetAllInventoryProductsResponseDTO>();
           
            foreach(clsProductInventory productInventory in clsProductInventory.getProductsInventoryAsObjectList())
            {
                clsGetAllInventoryProductsResponseDTO dto = new clsGetAllInventoryProductsResponseDTO
                {
                    productID = productInventory.productID,
                    productInventoryID = productInventory.productID,
                    category = productInventory.product.category ,
                    name = productInventory.product.name , 
                    description = productInventory.product.description ,
                    sku = productInventory.sku ,
                    image = productInventory.image ,
                    color = productInventory.color ,
                    capacityInGB = productInventory.capacityInGB ,
                    priceInJOD = productInventory.priceInJOD ,
                    stockQuantity = productInventory.stockQuantity 
                };

                list.Add(dto);

            }

            return Ok(list);
        }




        [HttpPost("Products/GetAllInventoryProductsOfCategory", Name = "GetAllInventoryProductsOfCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllInventoryProductsOfCategory([FromBody] clsGetAllInventoryProductsOfCategoryRequestDTO requestDTO)
        {
            Console.WriteLine($"DEBUG: {requestDTO.category}");

            List<clsGetAllInventoryProductsResponseDTO> list = new List<clsGetAllInventoryProductsResponseDTO>();

            foreach (clsProductInventory productInventory in clsProductInventory.getProductsInventoryOfCategoryAsObjectList(new clsProductDTO { category = requestDTO.category}))
            {
                clsGetAllInventoryProductsResponseDTO dto = new clsGetAllInventoryProductsResponseDTO
                {
                    productID = productInventory.productID,
                    productInventoryID = productInventory.productID,
                    category = productInventory.product.category,
                    name = productInventory.product.name,
                    description = productInventory.product.description,
                    sku = productInventory.sku,
                    image = productInventory.image,
                    color = productInventory.color,
                    capacityInGB = productInventory.capacityInGB,
                    priceInJOD = productInventory.priceInJOD,
                    stockQuantity = productInventory.stockQuantity
                };

                list.Add(dto);

            }

            Console.WriteLine($"DEBUG: ListSize = {list.Count}");
            Console.WriteLine($"DEBUG: Data = {list}");

            return Ok(list);
        }



        [HttpPost("Products/PurchaseProduct", Name = "PurchaseProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PurchaseProduct([FromBody] clsPurchaseProductRequestDTO requestDTO)
        {
            Console.WriteLine($"DEBUG: AccountID = {requestDTO.accountID}");

            clsDeliveryLocationDTO deliveryLocationDTO = new clsDeliveryLocationDTO {country = requestDTO.country , city = requestDTO.city , area = requestDTO.area , street = requestDTO.street , latitude = requestDTO.latitude , longitude = requestDTO.longitude , receiverPhoneNumber = requestDTO.receiverPhoneNumber };
            clsPaymentMethodDTO paymentMethodDTO = new clsPaymentMethodDTO { paymentMethodID = requestDTO.paymentMethodID };
            clsOrderDTO orderDTO = new clsOrderDTO {accountID = requestDTO.accountID};
            clsOrderItemsDTO orderItemsDTO = new clsOrderItemsDTO { productInventoryID = requestDTO.productInventoryID };

            bool isOrderPlaced = clsOrder.placeOrder(deliveryLocationDTO,paymentMethodDTO,orderDTO,orderItemsDTO);

            return Ok(new clsPurchaseProductResponseDTO { isSucceed = isOrderPlaced } );
        }



        [HttpPost("Orders/GetAccountOrders", Name = "GetAccountOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAccountOrders([FromBody] clsGetAccountOrdersRequestDTO requestDTO)
        {
            if(requestDTO.accountID <= 0)
            {
                return BadRequest("Invalid account id");
            }

            List<clsPlacedOrderDetailsDTO> list = clsOrder.getAccountOrdersByAccountID(new clsAccountDTO { accountID = requestDTO.accountID });

            return Ok(list);
        }



        [HttpPost("Profile/GetProfileInformation", Name = "GetProfileInformation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProfileInformation([FromBody] clsGetProfileInformationRequestDTO requestDTO)
        {

            if(requestDTO.userID <= 0)
            {
                return BadRequest("Invalid UserID");
            }

            clsUser user = clsUser.getUserByUserID(new clsUserDTO { userID = requestDTO.userID });
            clsPerson person = clsPerson.getPersonByPersonID(new clsPersonDTO { personID = user.personID });
            clsAccount account = clsAccount.getAccountByUserID(new clsUserDTO { userID = user.userID });

            List<clsGetProfileInformationResponseDTO> list = new List<clsGetProfileInformationResponseDTO>();
            list.Add(new clsGetProfileInformationResponseDTO
            {
                personID = person.personID,
                firstName = person.firstName,
                secondName = person.secondName,
                thirdName = person.thirdName,
                lastName = person.lastName,
                username = user.username,
                phoneNumber = person.phoneNumber,
                email = person.email,
                gender = (int)person.gender,
                userID = user.userID,
                accountID = account.userID,
                loyaltyPoints = account.loyaltyPoints,
                isActive = account.isActive,
                creationDateTime = account.creationDateTime
               
            });

            return Ok(list);

        }



        [HttpPost("Profile/UpdateInformation", Name = "UpdateInformation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateInformation([FromBody] clsUpdateProfileInformationRequestDTO requestDTO)
        {
            Console.WriteLine($"DEBUG: UserID = {requestDTO.userID}");
            Console.WriteLine($"DEBUG: Person = {requestDTO.personID}");

            if (requestDTO.personID <= 0)
            {
                return BadRequest("Invalid PersonID");
            }

            if(requestDTO.userID <= 0)
            {
                return BadRequest("Invalid UserID");
            }

            clsUser user = clsUser.getUserByUserID(new clsUserDTO { userID = requestDTO.userID });

            if (clsUser.doesUsernameExist(new clsUserDTO {username = requestDTO.username }) && user.username != requestDTO.username)
            {
                return BadRequest("Username already exists");
            }            


            clsPersonDTO personDTO = new clsPersonDTO {personID = requestDTO.personID , firstName = requestDTO.firstName , secondName = requestDTO.secondName , thirdName = requestDTO.thirdName , lastName = requestDTO.lastName , phoneNumber = requestDTO.phoneNumber , email = requestDTO.email , gedner = requestDTO.gender};
            clsUserDTO userDTO = new clsUserDTO{ userID = requestDTO.userID , username = requestDTO.username , password = requestDTO.password};

            bool isSucceed = clsUser.updateUserInformation(personDTO, userDTO);


            List<clsUpdateProfileInformationResponseDTO> list = new List<clsUpdateProfileInformationResponseDTO>();
            list.Add(new clsUpdateProfileInformationResponseDTO { isSucceed = isSucceed});

            return Ok(list);
        }



    }
}
