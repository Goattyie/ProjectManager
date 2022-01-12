var commentType = 1;
var errorBlock;
var filters = {};
var basicUrl = document.location.protocol + "//" + document.location.host;

document.addEventListener("DOMContentLoaded", function (event) {
    errorBlock = document.getElementById("error");
    searchString = new URLSearchParams(window.location.search);

    filters["project"] = searchString.get('project');
    filters["date"] = searchString.get('date');

    console.log(filters)
    });

document.getElementById("flexRadioDefault1").addEventListener("change", function (event) {
    document.getElementById("form-file-type").style.display = "none";
    document.getElementById("form-text-type").style.display = "block";
    commentType = 1;
});

document.getElementById("flexRadioDefault2").addEventListener("change", function (event) {
    document.getElementById("form-text-type").style.display = "none";
    document.getElementById("form-file-type").style.display = "block";
    commentType = 2;
});

document.getElementById("create-task").addEventListener("submit", function (event) {
    event.preventDefault();

    //Создаем объект данных
    let sendObject = {};
    sendObject["task"] = {};
    sendObject["comment"] = {};
    sendObject["task"]["taskName"] = document.getElementById("create-task-name").value;
    var index = document.getElementById("create-project-name").options.selectedIndex;

    if (index == 0) {
        errorBlock.innerHTML = "Проект не выбран.";
        return;
    }

    sendObject["task"]["projectId"] = document.getElementById("create-project-name").options[index].value;
    var projectName = document.getElementById("create-project-name").options[index].text;
    sendObject["task"]["startDate"] = document.getElementById("create-startdt").value;
    sendObject["task"]["endDate"] = document.getElementById("create-enddt").value;
    sendObject["comment"]["commentType"] = commentType;
    sendObject["comment"]["content"] = (commentType == 1) ? document.getElementById("create-comment-text").value : document.getElementById("create-comment-file").value;
    console.log(sendObject);

    //Проверка на ошибки
    if (!isCurrectData(sendObject)) {
        return;
    }

    console.log("Можно отправлять");
    //Отправка на сервер
    var result = sendObjectPost(sendObject, projectName ,basicUrl + "/task/")
    if(result == 200){
        errorBlock.innerHTML = "Объект успешно добавлен";
    }
});
function isCurrectData(obj) {
    errorBlock.innerHTML = "";
    if (obj["task"]["projectId"] == '') {
        errorBlock.innerHTML = "Проект не выбран";
        return false;
    }
    if (obj["task"]["taskName"] == '') {
        errorBlock.innerHTML = "Название задачи не указано";
        return false;
    }
    if (obj["task"]["startDate"] == '') {
        errorBlock.innerHTML = "Дата начала не указана";
        return false;
    }
    if (obj["task"]["endDate"] == '') {
        errorBlock.innerHTML = "Дата окончания не указана";
        return false;
    }
    if (obj["task"]["startDate"] > obj["task"]["endDate"]) {
        errorBlock.innerHTML = "Дата начала не может быть больше даны конца";
        return false;
    }
    if (obj["comment"]["content"] == '') {
        errorBlock.innerHTML = "Описание задачи не указано";
        return false;
    }
    return true;
}

function sendObjectPost(obj, projectName, url) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, false);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    var json = JSON.stringify(obj)
    console.log(json)
    xhr.send(json);
    console.log(xhr.response);
    console.log(JSON.parse(xhr.response)["id"]);
    if(xhr.status == 200){
        addRow(obj, projectName, "task/" + JSON.parse(xhr.response)["id"]);
    }
    return xhr.status 
}

function addRow(obj, projectName, link) {
    startDate = new Date(obj["task"]["startDate"]);
    endDate = new Date(obj["task"]["endDate"]);

    table = document.getElementById("task-table");
    tbody = table.getElementsByTagName("tbody")[0]
    tr = document.createElement("tr");

    tdProjectName = document.createElement("td");
    tdProjectName.setAttribute('scope', 'col');
    tdProjectName.innerHTML = projectName;

    tdSpendTime = document.createElement("td");
    tdSpendTime.setAttribute('scope', 'col');
    tdSpendTime.innerHTML = calculateSpendTime(startDate, endDate);

    tdTaskName = document.createElement("td");
    tdTaskName.setAttribute('scope', 'col');

    taskLink = document.createElement("a");
    taskLink.setAttribute('href', link);
    taskLink.setAttribute('class', 'btn');
    taskLink.innerHTML = obj["task"]["taskName"];

    tdTaskName.appendChild(taskLink);

    tdStartDate = document.createElement("td");
    tdStartDate.setAttribute('scope', 'col');
    tdStartDate.innerHTML = DateAsString(startDate);

    tdEndDate = document.createElement("td");
    tdEndDate.setAttribute('scope', 'col');
    tdEndDate.innerHTML = DateAsString(endDate);

    tr.appendChild(tdProjectName);
    tr.appendChild(tdSpendTime);
    tr.appendChild(tdTaskName);
    tr.appendChild(tdStartDate);
    tr.appendChild(tdEndDate);

    tbody.appendChild(tr);
}

function calculateSpendTime(startTime, endTime) {
    var hourDiff = endTime - startTime;
    var minDiff = hourDiff / 60 / 1000; //in minutes
    var hours = Math.floor(minDiff / 60); //in hours
    var minutes = minDiff % 60;
    if (hours.toString().length == 1) {
        hours = '0' + hours.toString();
    }
    if (minutes.toString().length == 1) {
        minutes = '0' + minutes.toString();
    }
    return hours.toString() + ":" + minutes.toString()
}

function DateAsString(date) {
    var day = date.getDate().toString();
    var month = (date.getMonth() + 1).toString();
    var year = date.getFullYear().toString();
    var hours = date.getHours().toString();
    var minutes = date.getMinutes().toString();

    if (day.length == 1) {
        day = '0' + day;
    }
    if (month.length == 1) {
        month = '0' + month;
    }
    if (hours.length == 1) {
        hours = '0' + hours;
    }
    if (minutes.length == 1) {
        minutes = '0' + minutes;
    }


    return day + '.' + month + '.' + year + ' ' + hours + ':' + minutes;
}

document.getElementById("filter-project").addEventListener("change", function (event) {
    var index = document.getElementById("filter-project").options.selectedIndex;
    filters["project"] = document.getElementById("filter-project").options[index].text;
    acceptFilters();
});

document.getElementById("filter-date").addEventListener("change", function (event) {
    filters["date"] = document.getElementById("filter-date").value;
    acceptFilters();
});


function acceptFilters(){
    let projectFilterStr = null;
    let dateFilterStr = null;
    if(filters["project"] != null){
        projectFilterStr="project=" + filters["project"];
    }
    if(filters["date"] != null){
        dateFilterStr="date=" + filters["date"];
    }
    window.location = basicUrl + "?" + projectFilterStr + "&" + dateFilterStr;
}

document.getElementById("no-filters").addEventListener("click", function(event){
    window.location = basicUrl;
});