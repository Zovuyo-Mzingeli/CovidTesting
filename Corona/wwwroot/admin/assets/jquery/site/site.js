﻿c$(function () {         $('button[data-toggle="modal"]').click(function (event) {             var url = $(this).data('url');             $.get(url).done(function (data) {                 $('#modal-placeholder').html(data);                 $('#modal-placeholder > .modal').modal('show');             });         });     });       placeholderElement.on('click', '[data-save="modal"]', function (event) {         event.preventDefault();          var form = $(this).parents('.modal').find('form');         var actionUrl = form.attr('action');         var dataToSend = form.serialize();          $.post(actionUrl, dataToSend).done(function (data) {             placeholderElement.find('.modal').modal('hide');         });     });      $.post(actionUrl, dataToSend).done(function (data) {         var newBody = $('.modal-body', data);         placeholderElement.find('.modal-body').replaceWith(newBody);     });     placeholderElement.on('click', '[data-save="modal"]', function (event) {         event.preventDefault();          var form = $(this).parents('.modal').find('form');         var actionUrl = form.attr('action');         var dataToSend = form.serialize();          $.post(actionUrl, dataToSend).done(function (data) {             var newBody = $('.modal-body', data);             placeholderElement.find('.modal-body').replaceWith(newBody);              var isValid = newBody.find('[name="IsValid"]').val() == 'True';             if (isValid) {                 placeholderElement.find('.modal').modal('hide');             }         });     }); $(function () {         $('button[data-toggle="modal"]').click(function (event) {             var url = $(this).data('url');             $.get(url).done(function (data) {                 $('#modal-placeholder').html(data);                 $('#modal-placeholder > .modal').modal('show');             });         });     });       placeholderElement.on('click', '[data-save="modal"]', function (event) {         event.preventDefault();          var form = $(this).parents('.modal').find('form');         var actionUrl = form.attr('action');         var dataToSend = form.serialize();          $.post(actionUrl, dataToSend).done(function (data) {             placeholderElement.find('.modal').modal('hide');         });     });      $.post(actionUrl, dataToSend).done(function (data) {         var newBody = $('.modal-body', data);         placeholderElement.find('.modal-body').replaceWith(newBody);     });     placeholderElement.on('click', '[data-save="modal"]', function (event) {         event.preventDefault();          var form = $(this).parents('.modal').find('form');         var actionUrl = form.attr('action');         var dataToSend = form.serialize();          $.post(actionUrl, dataToSend).done(function (data) {             var newBody = $('.modal-body', data);             placeholderElement.find('.modal-body').replaceWith(newBody);              var isValid = newBody.find('[name="IsValid"]').val() == 'True';             if (isValid) {                 placeholderElement.find('.modal').modal('hide');             }         });     });     showInPopup = (url, title) => {     $.ajax({         type: 'GET',         url: url,         success: function (res) {             $('#form-modal .modal-body').html(res);             $('#form-modal .modal-title').html(title);             $('#form-modal').modal('show');         }     }) }  jQueryAjaxPost = form => {     try {         $.ajax({             type: 'POST',             url: form.action,             data: new FormData(form),             contentType: false,             processData: false,             success: function (res) {                 if (res.isValid) {                     $('#view-all').html(res.html)                     $('#form-modal .modal-body').html('');                     $('#form-modal .modal-title').html('');                     $('#form-modal').modal('hide');                 }                 else                     $('#form-modal .modal-body').html(res.html);             },             error: function (err) {                 console.log(err)             }         })         //to prevent default form submit event         return false;     } catch (ex) {         console.log(ex)     } } jQueryAjaxDelete = form => {     if (confirm('Are you sure to delete this record ?')) {         try {             $.ajax({                 type: 'POST',                 url: form.action,                 data: new FormData(form),                 contentType: false,                 processData: false,                 success: function (res) {                     $('#view-all').html(res.html);                 },                 error: function (err) {                     console.log(err)                 }             })         } catch (ex) {             console.log(ex)         }     }      //prevent default form submit event     return false; } //$(function () { //    $("#loaderbody").addClass('hide');  //    $(document).bind('ajaxStart', function () { //        $("#loaderbody").removeClass('hide'); //    }).bind('ajaxStop', function () { //        $("#loaderbody").addClass('hide'); //    }); //}); 