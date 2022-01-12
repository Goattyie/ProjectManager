var errorBlock;
var basicUrl = document.location.protocol + "//" + document.location.host;

document.addEventListener("DOMContentLoaded", function (event) {
    errorBlock = document.getElementById("error");
});

document.getElementById("update-task").addEventListener("submit", function (event) {
    event.preventDefault();

    //Создаем объект данных
    let sendObject = {};
    var taskId = document.getElementById("taskId").innerHTML;
    sendObject["taskName"] = document.getElementById("create-task-name").value;
    var index = document.getElementById("create-project-name").options.selectedIndex;
    sendObject["projectId"] = document.getElementById("create-project-name").options[index].value;
    var projectName = document.getElementById("create-project-name").options[index].text;
    sendObject["startDate"] = document.getElementById("create-startdt").value;
    sendObject["endDate"] = document.getElementById("create-enddt").value;
    sendObject["createDate"] = document.getElementById("create-createdt").value;
    sendObject["updateDate"] = document.getElementById("create-updatedt").value;
    console.log(sendObject);

    //Проверка на ошибки
    if (!isCurrectData(sendObject)) {
        return;
    }

    console.log("Можно отправлять");
    //Отправка на сервер
    var result = sendObjectPut(sendObject, basicUrl + "/" + taskId)

    if(result == 200){
    //Добавление в таблицу
    errorBlock.innerHTML = "Задача обновлена";
    }
});

function isCurrectData(obj) {
    errorBlock.innerHTML = "";
    if (obj["projectId"] == '') {
        errorBlock.innerHTML = "Проект не выбран";
        return false;
    }
    if (obj["taskName"] == '') {
        errorBlock.innerHTML = "Название задачи не указано";
        return false;
    }
    if (obj["startDate"] == '') {
        errorBlock.innerHTML = "Дата начала не указана";
        return false;
    }
    if (obj["endDate"] == '') {
        errorBlock.innerHTML = "Дата окончания не указана";
        return false;
    }
    if (obj["startDate"] > obj["endDate"]) {
        errorBlock.innerHTML = "Дата начала не может быть больше даны конца";
        return false;
    }
    if (obj["comment"] == '') {
        errorBlock.innerHTML = "Описание задачи не указано";
        return false;
    }
    return true;
}
function sendObjectPut(obj, url) {
    var xhr = new XMLHttpRequest();
    xhr.open("PUT", url, false);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    var json = JSON.stringify(obj)
    console.log(json)
    xhr.send(json);
    console.log(xhr.status)
    return xhr.status
}

document.getElementById("create-comment").addEventListener("submit", function (event) {
    event.preventDefault();

    let comment = {};
    comment["taskId"] = document.getElementById("taskId").innerHTML;
    comment["content"] = document.getElementById("comment-text").value;
    comment["commentType"] = 1;

    if(comment["content"] != ''){
        createCommentRequest(comment, basicUrl + "/api/comment/")
    }

});

function createCommentRequest(obj, url){
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, false);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    var json = JSON.stringify(obj)
    console.log(json)
    xhr.send(json);
    console.log(xhr.status)
    if(xhr.status == 200){
        addComment(xhr.response["id"], obj["commentType"], obj["content"])
    }
}

function addComment(id, commentType, content){
    table = document.getElementById("comment-table");
    tbody = table.getElementsByTagName("tbody")[0]
    tr = document.createElement("tr");
    td = document.createElement("td");
    td.innerHTML = commentType;
    td2 = document.createElement("td");
    td2.innerHTML = content; 

    button = document.createElement("button");
    button.setAttribute("class", "btn btn-danger");
    button.setAttribute("onclick", "deleteComment(" + id + ")");
    button.innerHTML = "Удалить";
    td3 = document.createElement("td");
    td3.appendChild(button);

    tr.appendChild(td);
    tr.appendChild(td2);
    tr.appendChild(td3);
    tbody.appendChild(tr);
}

function deleteComment(id){
    
    var xhr = new XMLHttpRequest();
    xhr.open("DELETE", basicUrl + "/api/comment/" + id, false);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.send();
    if(xhr.status == 200){
        removeRowById(id);
    }
}

function removeRowById(id){
    var tr = document.getElementById(id);
    tr.parentElement.removeChild(tr);
}