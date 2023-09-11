
// Specify the URL of your PDF file
const pdfUrl = '';

// Create a reference to the container div
const pdfContainer = document.getElementById('pdf-container');

// Initialize PDF.js
pdfjsLib.GlobalWorkerOptions.workerSrc = 'https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.11.338/pdf.worker.min.js';

// Load and render the PDF
pdfjsLib.getDocument(pdfUrl).promise.then(pdfDoc => {
    // Set the initial page to display (page 1)
    const pageNum = 1;

    // Render the PDF page into the container
    pdfDoc.getPage(pageNum).then(page => {
        const canvas = document.createElement('canvas');
        pdfContainer.appendChild(canvas);
        const context = canvas.getContext('2d');
        const viewport = page.getViewport({ scale: 1.0 });
        canvas.height = viewport.height;
        canvas.width = viewport.width;
        page.render({ canvasContext: context, viewport: viewport });
    });
});
