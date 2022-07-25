﻿using System;
using System.ComponentModel;
using System.IO;

namespace Sdcb.PaddleOCR.Models
{
    public class FullOcrModel
    {
        public FullOcrModel(DetectionModel detectionModel, ClassificationModel? classificationModel, RecognizationModel recognizationModel)
        {
            DetectionModel = detectionModel;
            ClassificationModel = classificationModel;
            RecognizationModel = recognizationModel;
        }

        public FullOcrModel(DetectionModel detectionModel, RecognizationModel recognizationModel)
        {
            DetectionModel = detectionModel;
            RecognizationModel = recognizationModel;
        }

        public DetectionModel DetectionModel { get; init; }

        public ClassificationModel? ClassificationModel { get; init; }

        public RecognizationModel RecognizationModel { get; init; }

        [Obsolete]
        public static FullOcrModel FromDirectory(string modelFolderPath, string labelFilePath, ModelVersion version)
        {
            return new FullOcrModel(
                DetectionModel.FromDirectory(Path.Combine(modelFolderPath, "det")), 
                ClassificationModel.FromDirectory(Path.Combine(modelFolderPath, "cls")), 
                RecognizationModel.FromDirectory(Path.Combine(modelFolderPath, "rec"), labelFilePath, version));
        }

        [Obsolete]
        public static FullOcrModel FromDirectory(string detectionModelDir, string classificationModelDir, string recognitionModelDir, string labelFilePath, ModelVersion version)
        {
            return new FullOcrModel(
                DetectionModel.FromDirectory(detectionModelDir),
                ClassificationModel.FromDirectory(classificationModelDir),
                RecognizationModel.FromDirectory(recognitionModelDir, labelFilePath, version));
        }
    }
}

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Reserved to be used by the compiler for tracking metadata.
    /// This class should not be used by developers in source code.
    /// This dummy class is required to compile records when targeting .NET Standard
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class IsExternalInit
    {
    }
}