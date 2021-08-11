
import { FileUploadError } from "./fileuploaderror";
import { FileUploadSave } from "./fileuploadsave";

export class FileUpload {
    excelFile: string;
    fileUploadSave: FileUploadSave[]
    fileUploadError: FileUploadError[]
}
