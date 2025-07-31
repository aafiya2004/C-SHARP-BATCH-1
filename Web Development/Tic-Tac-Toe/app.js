let btn=document.querySelectorAll(".box");
let rst=document.querySelector("#reset");
let msgcontain=document.querySelector(".msgContainer");
let m=document.querySelector("#msg");
let newbtn=document.querySelector("#new");

let turnO=true;
let clickCount=0;

const winPatterns=[
    [0,1,2],
    [3,4,5],
    [6,7,8],
    [0,3,6],
    [1,4,7],
    [2,5,8],
    [0,4,8],
    [2,4,6]
];

btn.forEach((box) => {
box.addEventListener("click",()=>{
    if(turnO){
        box.innerText="O";
        turnO=false;
       
    }
    else{
        box.innerText="X";
        turnO=true;
      
    }
    clickCount++;
    box.disabled=true;
    checkWinner();
    let isWinner=checkWinner();
    if(clickCount===9 && !isWinner){
          drawGame();
    }
 
});
});


const resetGame=()=>{
    turnO=true;
    clickCount=0;
    enablebox();
    msgcontain.classList.add("hide");

}
const disablebox=()=>{
    for(let box of btn){
        box.disabled=true;
    }
}
const enablebox=()=>{
    for(let box of btn){
        box.disabled=false;
        box.innerText="";
    }

}


const showWinner=(winner)=>{
    m.innerText=`Congratulations! The Winner is ${winner}`;
    msgcontain.classList.remove("hide");
    disablebox();

}

const checkWinner=()=>{
    for(let patterns of winPatterns){
        let pos1=btn[patterns[0]].innerText;
        let pos2=btn[patterns[1]].innerText;
        let pos3=btn[patterns[2]].innerText;

        if(pos1!="" && pos2!="" && pos3!=""){
            if(pos1===pos2 && pos2==pos3 && clickCount<=9){
                console.log("Winner!",pos1);
                showWinner(pos1);
            }
          
        }
        
    }

}
const drawGame=()=>{
        m.innerText="The Match was Drawn";
        msgcontain.classList.remove("hide");
        disablebox();
}

rst.addEventListener("click",resetGame);
newbtn.addEventListener("click",resetGame);
