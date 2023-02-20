function phi = ComputeTwist(E_wa, E_wb)

E_ab = E_wa\E_wb;
phib = logSE3(E_ab);
phi = unbrac(phib);

