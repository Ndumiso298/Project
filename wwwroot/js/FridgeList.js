
    
        // SweetAlert Delete Confirmation
            function confirmDelete(event, form) {
                event.preventDefault();

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
                },
            buttonsStyling: false
            });

            swalWithBootstrapButtons.fire({
                title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                form.submit();
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                swalWithBootstrapButtons.fire({
                    title: "Cancelled",
                    text: "User deletion cancelled",
                    icon: "error"
                });
                }
            });
        }

            document.addEventListener('DOMContentLoaded', function () {
            // Tooltip setup
            const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
            tooltipTriggerList.map(function (tooltipTriggerEl) {
                return new bootstrap.Tooltip(tooltipTriggerEl);
            });

            // Create Search Input
            const searchInput = document.createElement('input');
            searchInput.type = 'text';
            searchInput.placeholder = 'Search users...';
            searchInput.className = 'form-control form-control-sm w-25 ms-auto';
            const cardHeader = document.querySelector('.card-header');
            cardHeader.appendChild(searchInput);

            const rows = document.querySelectorAll('#userTable tbody tr');

            // 🔍 Search Functionality
            searchInput.addEventListener('keyup', function () {
                const searchText = this.value.toLowerCase();
                rows.forEach(row => {
                    const text = row.textContent.toLowerCase();
            row.style.display = text.includes(searchText) ? '' : 'none';
                });
            });

            // 🔽 Filter Functionality
            document.querySelectorAll('.dropdown-menu .dropdown-item').forEach(item => {
                item.addEventListener('click', function (e) {
                    e.preventDefault();
                    const filter = this.textContent.trim().toLowerCase();

                    rows.forEach(row => {
                        const badge = row.querySelector('.badge');
                        const status = badge ? badge.textContent.trim().toLowerCase() : '';

                        if (filter === 'all users') {
                            row.style.display = '';
                        } else if (status.includes(filter)) {
                            row.style.display = '';
                        } else {
                            row.style.display = 'none';
                        }
                    });

                    // Update dropdown button text
                    const btn = document.getElementById('dropdownMenuButton');
                    btn.innerHTML = `<i class="bi bi-filter me-1"></i> ${this.textContent}`;
                });
            });
        });
   