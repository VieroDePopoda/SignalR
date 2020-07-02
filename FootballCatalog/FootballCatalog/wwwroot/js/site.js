/// <reference path="../lib/signalr/browser/signalr.js" />
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(() => {
    let connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build();

    connection.start();

    connection.on("refreshPlayers", function () {
        loadData();
    });

    connection.on("refreshOpts", function () {
        loadOpt();
    });

    loadData();

    function loadOpt() {
        $('#sel').empty();
        $.ajax({
            url: '/Home/GetTeams',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    $('#sel').append($("<option></option>")
                        .attr("value", v.id)
                        .text(v.name)); 
                });
            },
            error: (error) => {
                console.log(error);
            }
        });
    }
    function loadData() {
        var tr = '';

        $.ajax({
            url: '/Home/GetPlayers',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr = tr + `<tr>
                        <td>${v.name}</td>
                        <td>${v.surname}</td>
                        <td>${v.gender}</td>
                        <td>${v.birthday}</td>
                        <td>${v.team.name}</td>
                        <td>${v.country}</td>
                        <td><a href='/Players/Edit?id=${v.id}'</a>Изменить
                            <a href='/Players/Delete?id=${v.id}'</a>Удалить</td>
                    </tr>`;
                });

                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error);
            }
        });
    }
});

function addTeam() {
    var teamName = $("#teamField").val();
    $.ajax({
        type: "POST",
        url: 'AddTeam',
        data:
            { team: teamName },
        success: function () {
            loadOpt();
        },
        error: function (error) {
            alert(error.val);
        }
    });
};

function showHide() {
    var x = document.getElementById("ShowHideThis");
    var btn = document.getElementById("AddTeamButton");
    if (x.style.display === "none") {
        x.style.display = "block";
        btn.value = "-";
    } else {
        x.style.display = "none";
        btn.value = "+";
    }
}