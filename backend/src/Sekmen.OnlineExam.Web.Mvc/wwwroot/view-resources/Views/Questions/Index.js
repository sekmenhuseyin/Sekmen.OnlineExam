(function ($) {
    var _questionService = abp.services.app.question,
        l = abp.localization.getSource('OnlineQuestion'),
        _$modal = $('#QuestionCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#QuestionsTable');

    var _$questionsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _questionService.getAll,
            inputFilter: function () {
                return $('#QuestionsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$questionsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'order',
                sortable: false
            },
            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <a href="/Answers?questionId=${row.id}" class="btn btn-sm bg-primary answers">`,
                        `       <i class="fas fa-folder-plus"></i> ${l('Answers')}`,
                        '   </a>',
                        `   <button type="button" class="btn btn-sm bg-secondary edit-question" data-question-id="${row.id}" data-toggle="modal" data-target="#QuestionEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-question" data-question-id="${row.id}" data-question-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.validate({
        rules: {
            Password: "required",
            ConfirmPassword: {
                equalTo: "#Password"
            }
        }
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var question = _$form.serializeFormToObject();
        question.roleNames = [];
        var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
        if (_$roleCheckboxes) {
            for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                question.roleNames.push(_$roleCheckbox.val());
            }
        }

        abp.ui.setBusy(_$modal);
        _questionService.create(question).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$questionsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-question', function () {
        var questionId = $(this).attr("data-question-id");
        var questionName = $(this).attr('data-question-name');

        deleteQuestion(questionId, questionName);
    });

    function deleteQuestion(questionId, questionName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                questionName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _questionService.delete({
                        id: questionId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$questionsTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-question', function (e) {
        var questionId = $(this).attr("data-question-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Questions/EditModal?questionId=' + questionId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#QuestionEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#QuestionCreateModal"]', (e) => {
        $('.nav-tabs a[href="#question-details"]').tab('show')
    });

    abp.event.on('question.edited', (data) => {
        _$questionsTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$questionsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$questionsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
