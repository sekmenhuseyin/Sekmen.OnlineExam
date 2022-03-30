(function ($) {
    var _answerService = abp.services.app.answer,
        l = abp.localization.getSource('OnlineAnswer'),
        _$modal = $('#AnswerCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#AnswersTable');

    var _$answersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _answerService.getAll,
            inputFilter: function () {
                return $('#AnswersSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$answersTable.draw(false)
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
                data: 'isCorrect',
                sortable: false
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-answer" data-answer-id="${row.id}" data-toggle="modal" data-target="#AnswerEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-answer" data-answer-id="${row.id}" data-answer-name="${row.name}">`,
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

        var answer = _$form.serializeFormToObject();
        answer.roleNames = [];
        var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
        if (_$roleCheckboxes) {
            for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                answer.roleNames.push(_$roleCheckbox.val());
            }
        }

        abp.ui.setBusy(_$modal);
        _answerService.create(answer).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$answersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-answer', function () {
        var answerId = $(this).attr("data-answer-id");
        var answerName = $(this).attr('data-answer-name');

        deleteAnswer(answerId, answerName);
    });

    function deleteAnswer(answerId, answerName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                answerName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _answerService.delete({
                        id: answerId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$answersTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-answer', function (e) {
        var answerId = $(this).attr("data-answer-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Answers/EditModal?answerId=' + answerId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#AnswerEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#AnswerCreateModal"]', (e) => {
        $('.nav-tabs a[href="#answer-details"]').tab('show')
    });

    abp.event.on('answer.edited', (data) => {
        _$answersTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$answersTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$answersTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
