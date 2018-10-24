

var this_js_script = $('script[src*=comment-module]');
$(function () {

    $('#comments-container').comments({

        profilePictureURL: 'https://viima-app.s3.amazonaws.com/media/public/defaults/user-icon.png',
        roundProfilePictures: true,
        textareaRows: 1,
        enableAttachments: true,
        maxRepliesVisible: 3,

        getComments: function (success, error) {
            var form = $('#__AjaxAntiForgeryForm');
            var token = $('input[name="__RequestVerificationToken"]', form).val();
            $.ajax({
                type: "post",
                data: {
                    __RequestVerificationToken: token,
                    entityType: this_js_script.attr('model_entity_type'),
                    entityID: this_js_script.attr('model_id')
                },
                url: "/Comment/getComments",
                success: function (result) {
                    
                    var json = JSON.parse(result)
                    if (json['success']) {
                        success(json['commentsGetViewModel'])
                    }
                    else {
                        alert(json['message']);
                    }
                },
                error: error
            });
        },
        postComment: function (commentJSON, success, error) {
            var form = $('#__AjaxAntiForgeryForm');
            var token = $('input[name="__RequestVerificationToken"]', form).val();
            commentJSON['__RequestVerificationToken'] = token;
            $.ajax({
                type: 'post',
                url: "/Comment/postComment?entityType=" + this_js_script.attr('model_entity_type') + "&entityID=" + this_js_script.attr('model_id'),
                data: commentJSON,
                success: function (result) {
                    var json = JSON.parse(result)
                    if (json['success']) {
                        success(json)
                    }
                    else {
                        alert(json['message']);
                    }
                },
                error: error
            });
        },
        upvoteComment: function (commentJSON, success, error) {
            var form = $('#__AjaxAntiForgeryForm');
            var token = $('input[name="__RequestVerificationToken"]', form).val();
            var upvotesURL = '/Comment/upvoteComment/' + commentJSON.id;
            $.ajax({
                type: 'post',
                url: upvotesURL,
                data: {
                    __RequestVerificationToken: token
                },
                success: function (result) {
                    var json = JSON.parse(result)
                    if (json['success']) {
                        success(commentJSON)
                    }
                    else {
                        alert(json['message']);
                    }
                },
                error: error
            });
        },
        uploadAttachments: function (commentArray, success, error) {
            var responses = 0;
            var successfulUploads = [];

            var serverResponded = function () {
                responses++;

                // Check if all requests have finished
                if (responses == commentArray.length) {

                    // Case: all failed
                    if (successfulUploads.length == 0) {
                        error();

                        // Case: some succeeded
                    } else {
                        success(successfulUploads)
                    }
                }
            }

            $(commentArray).each(function (index, commentJSON) {

                // Create form data
                var formData = new FormData();
                $(Object.keys(commentJSON)).each(function (index, key) {
                    var value = commentJSON[key];
                    if (value) formData.append(key, value);
                });

                $.ajax({
                    url: "/Comment/postImageComment?entityType=" + this_js_script.attr('model_entity_type') + "&entityID=" + this_js_script.attr('model_id'),
                    type: 'POST',
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (commentJSON) {
                        successfulUploads.push(JSON.parse(commentJSON));
                        serverResponded();
                    },
                    error: function (data) {
                        serverResponded();
                    },
                });
            });
        },
        putComment: function (commentJSON, success, error) {
            $.ajax({
                type: 'post',
                url: "/Comment/editComment/" + commentJSON.id,
                data: commentJSON,
                success: function (comment) {
                    success(comment)
                },
                error: error
            });
        }

    });
});