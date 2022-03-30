(function ($) {
    var _examService = abp.services.app.exam,
        l = abp.localization.getSource('OnlineExam'),
        _$modal = $('#ExamCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ExamsTable');

    var _$examsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _examService.getAll,
            inputFilter: function () {
                return $('#ExamsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$examsTable.draw(false)
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
                data: 'duration',
                sortable: false
            },
            {
                targets: 3,
                data: 'questionCount',
                sortable: false
            },
            {
                targets: 4,
                data: 'isActive',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <a href="/Questions?examId=${row.id}" class="btn btn-sm bg-primary questions">`,
                        `       <i class="fas fa-folder-plus"></i> ${l('Questions')}`,
                        '   </a>',
                        `   <button type="button" class="btn btn-sm bg-secondary edit-exam" data-exam-id="${row.id}" data-toggle="modal" data-target="#ExamEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-exam" data-exam-id="${row.id}" data-exam-name="${row.name}">`,
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

        var exam = _$form.serializeFormToObject();
        exam.roleNames = [];
        var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
        if (_$roleCheckboxes) {
            for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                exam.roleNames.push(_$roleCheckbox.val());
            }
        }

        abp.ui.setBusy(_$modal);
        _examService.create(exam).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$examsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-exam', function () {
        var examId = $(this).attr("data-exam-id");
        var examName = $(this).attr('data-exam-name');

        deleteExam(examId, examName);
    });

    function deleteExam(examId, examName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                examName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _examService.delete({
                        id: examId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$examsTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-exam', function (e) {
        var examId = $(this).attr("data-exam-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Exams/EditModal?examId=' + examId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ExamEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#ExamCreateModal"]', (e) => {
        $('.nav-tabs a[href="#exam-details"]').tab('show')
    });

    abp.event.on('exam.edited', (data) => {
        _$examsTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$examsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$examsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
