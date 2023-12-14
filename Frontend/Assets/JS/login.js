const loginText = document.querySelector(".title-text .login");
const loginForm = document.querySelector("form.login");
const loginBtn = document.querySelector("label.login");
const signupBtn = document.querySelector("label.signup");
const signupLink = document.querySelector("form .signup-link a");
signupBtn.onclick = (()=>{
    loginForm.style.marginLeft = "-50%";
    loginText.style.marginLeft = "-50%";
});
loginBtn.onclick = (()=>{
    loginForm.style.marginLeft = "0%";
    loginText.style.marginLeft = "0%";
});
signupLink.onclick = (()=>{
    signupBtn.click();
    return false;
});


const email = document.querySelector("#email");
const password = document.querySelector("#password");
const buttonUp = document.querySelector("#Sing-Up");
const buttonIn = document.querySelector("#Sing-In");
// Validate Register Form
buttonUp.addEventListener('click',(evento) =>{
    evento.preventDefault();
    var emailUser = email.value;
    var registerPass = password.value;
    if (registerPass == "" || emailUser == "") {
        alert("Please Fill All Fields!");
        return false;
    }
    else{
        const endpoint = "http://localhost:5029/user/register"
        data = {
            "email": emailUser,
            "password": registerPass
        }

        fetch(endpoint,{
            method:'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then((res)=>{
            if(res.status === 200){
                var prueba = {
                    "id":"todos"
                }
                var Json = JSON.stringify(prueba);
                localStorage.setItem("prueba",Json)
                location.assign("/Index.html")
            }
            else if(res.status === 400){
                throw new Error('The user is already register')
            }
            else{
                throw new Error('Error in the register');
            }
        })
        .catch(error => {
            alert(error.message);
        })
    }
})

