const loginText = document.querySelector(".title-text .login");
const loginForm = document.querySelector("form.login");
const loginBtn = document.querySelector("label.login");
const signupBtn = document.querySelector("label.signup");
const signupLink = document.querySelector("form .signup-link a");
const signupButton = document.querySelector("#mkwtf");

signupBtn.onclick = (()=>{
    loginForm.style.marginLeft = "-50%";
    loginText.style.marginLeft = "-50%";
});
loginBtn.onclick = (()=>{
    loginForm.style.marginLeft = "0%";
    loginText.style.marginLeft = "0%";
});
signupButton.onclick = (()=>{
    loginForm.style.marginLeft = "-50%";
    loginText.style.marginLeft = "-50%";
    signupBtn.click();
    return false;
});



/* SIGN UP */
const user = document.querySelector("#user");
const email = document.querySelector("#email");
const password = document.querySelector("#password");
const buttonUp = document.querySelector("#sing-up");
const buttonIn = document.querySelector("#sing-in");

// Validate Register Form
buttonUp.addEventListener('click',(evento) =>{
    evento.preventDefault();
    var registerUser = user.value;
    var emailUser = email.value;
    var registerPass = password.value;
    if (registerUser == "" || registerPass == "" || emailUser == "") {
        alert("Please Fill All Fields!");
        return false;
    }
    else{
        const endpoint = "http://localhost:5029/user/register"
        data = {
            "username": registerUser,
            "password": registerPass,
            "email": emailUser
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
                location.assign("/Frontend/index.html")
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


/* LOGIN */
const emaillogin = document.querySelector("#email-login");
const passwordlogin = document.querySelector("#password-login");
buttonIn.addEventListener('click', (turism) => {
    turism.preventDefault()
    let loginEmail = emaillogin.value;
    let loginPassword = passwordlogin.value;
    if (loginEmail == "" || loginPassword == "") {
        alert("Please Fill All Fields!");
        return false;
    }
    else{
        const endpoint = "http://localhost:5029/user/Login";
        data = {
            "Email": loginEmail,
            "password": loginPassword
        };
        fetch(endpoint,{
            method:'POST',
            headers:{
                'Content-Type':'application/json'
            },
            body:JSON.stringify(data)
        }).then((res)=> {
            console.log(res);
            if(res.status===200){
                var prueba = {
                    "id":"todos"
                }
                var Json = JSON.stringify(prueba);
                localStorage.setItem("prueba",Json)
                location.assign("/Frontend/index.html")
            }
            else if(res.status===400){
                throw new Error("Wrong username or password");
            }
            else if(res.status===401){
                throw new Error("Wrong username or password");
            }
        }).catch(err=>alert(err))
    }
})