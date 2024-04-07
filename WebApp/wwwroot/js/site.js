// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    // Init movies table
    $('#movieTable').DataTable({
        "paging": false,
        "searching": false,
        "info": false,
        "ordering": true,
        columnDefs: [
            { orderable: false, targets: [2] } // Disable ordering for the fourth column (index 3)
        ]
    });

    // Get base path
    const basePath = window.location.protocol + '//' + window.location.hostname + (window.location.port ? ':' + window.location.port : '');

    // Init service
    const movieCategoryService = new MovieCategoryService(basePath);

    // Get movie id
    const path = window.location.pathname;
    const parts = path.split('/');
    let movieId = parts[parts.length - 1];

    // Add event listener to button "Add Category"
    $('#addCategoryButton').click(function (event) {
        let categorySelector = $('#categorySelector');
        let categoryId = categorySelector.val();
        let categoryTitle = $(`#categorySelector option[value=${categoryId}]`).text();

        console.log(categoryId);
        console.log(categoryTitle);

        movieCategoryService.addCategoryToMovie(movieId, categoryId)
            .then(data => {
                movieCategoryService.addCategoryElement(categoryId, categoryTitle);
            })
            .catch(error => {
                console.error('Failed to add category to movie:', error);
                alert('Failed to add category to movie.');
            });
    });

    // Add event listener to remove category when unchecked
    $('#movieCategoriesContainer').find('.check').on('change', function (event) {
        let categoryId = event.target.value;

        movieCategoryService.removeCategoryFromMovie(movieId, categoryId)
            .then(data => {
                movieCategoryService.removeCategoryElement(categoryId);
            })
            .catch(error => {
                console.error('Failed to remove category from movie:', error);
                alert('Failed to remove category from movie.');
            });
    });
});

class MovieCategoryService {

    constructor(baseUrl) {
        this.baseUrl = baseUrl;
    }

    async addCategoryToMovie(movieId, categoryId) {
        let url = `${this.baseUrl}/api/movie/${movieId}/category/${categoryId}`;

        try {
            const response = await fetch(url, {
                method: 'POST',
            });

            if (!response.ok) {
                throw new Error('Failed to add category to movie.');
            }
        }
        catch {
            console.error('Error: ', error);
            throw error;
        }
    }

    async removeCategoryFromMovie(movieId, categoryId) {
        let url = `${this.baseUrl}/api/movie/${movieId}/category/${categoryId}`;

        try {
            const response = await fetch(url, {
                method: 'DELETE',
            });

            if (!response.ok) {
                throw new Error('Failed to add category to movie.');
            }
        }
        catch {
            console.error('Error: ', error);
            throw error;
        }
    }

    addCategoryElement(categoryId, categoryTitle) {
        const element = `<div class="m-1 form-check" id="${categoryId}">
					       <input class="check form-check-input" type="checkbox" value="${categoryId}" checked/>
					       <label class="form-check-label">${categoryTitle}</label>
				       </div>`;

        $('#movieCategoriesContainer').append(element);
    }

    removeCategoryElement(categoryId) {
        $(`#${categoryId}.form-check`).remove();
    }
}
