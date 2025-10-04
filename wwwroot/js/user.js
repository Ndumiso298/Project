var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Admin/User/GetAll' },
        "columns": [
            { 
                "data": null, 
                "render": function (data) {
                    return `${data.firstName} ${data.lastName}`;
                }, 
                "width": "15%" 
            },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { 
                "data": "primaryLocation.city", 
                "width": "15%" 
            },
            { "data": "userRole", "width": "15%" },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd", userRole: "userRole" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    var lockButton = '';
                    
                    // Only Admin can lock/unlock
                    if (currentUserRole === 'Admin') {
                        if (lockout > today) {
                            lockButton = `
                                <a onclick="LockUnlock('${data.id}')" 
                                   class="btn btn-danger text-white" 
                                   style="cursor:pointer; width:100px;">
                                    <i class="bi bi-lock-fill"></i> Lock
                                </a>`;
                        } else {
                            lockButton = `
                                <a onclick="LockUnlock('${data.id}')" 
                                   class="btn btn-success text-white" 
                                   style="cursor:pointer; width:100px;">
                                    <i class="bi bi-unlock-fill"></i> UnLock
                                </a>`;
                        }
                    }

                    // Permission link visible to both Admin & Customer Service
                    var permissionLink = `
                        <a href="/Admin/User/RoleManagement?userId=${data.id}" 
                           class="btn btn-warning text-white" 
                           style="cursor:pointer; width:150px;">
                            <i class="bi bi-pencil-square"></i> Permission
                        </a>`;

                    return `<div class="text-center">${lockButton} ${permissionLink}</div>`;
                },
                "width": "25%"
            }
        ]
    });
}

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            } else {
                toastr.error(data.message);
            }
        }
    });
}
