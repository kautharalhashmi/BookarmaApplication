// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Selectors
const addBtn = document.querySelector("button");
const input = document.querySelector(".hola");
const ul = document.querySelector("ul");
const hideCheckbox = document.querySelector("#hide");

// Add 
addBtn.addEventListener("click", (e) => {
    e.preventDefault(); 
    const userValue = input.value.trim();
    
    if (userValue !== "") {
        const li = document.createElement("li");
        const spanName = document.createElement("span");
        const spanDelete = document.createElement("span");

        spanName.textContent = userValue;
        spanDelete.textContent = "delete";

        spanName.classList.add("name");
        spanDelete.classList.add("delete");
        li.appendChild(spanName);
        li.appendChild(spanDelete);
        ul.appendChild(li);
        input.value = "";
    }
});

// Delete 
ul.addEventListener("click", (e) => {
  if(e.target.classList=="delete"){
  e.target.parentElement.remove();
  }
});

// Hide 
hideCheckbox.addEventListener("change", (e) => {
    if (hideCheckbox.checked) {
        ul.style.display = "none";
    } else {
        ul.style.display = "block";
    }
});
