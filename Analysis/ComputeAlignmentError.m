function alignmentError = ComputeAlignmentError(peg_axialVector, hole_axialVector)

inner_prod = dot(peg_axialVector, hole_axialVector);
norm_prod = norm(peg_axialVector).*norm(hole_axialVector);
alignmentError = acosd(inner_prod./norm_prod);
